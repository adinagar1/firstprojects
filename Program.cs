using System;
using System.IO;
using System.Collections.Generic;

// הסרת כל הספריות הנדרשות.
class Program
{
    static void Main()
    {
        int port = 5000; // קביעת הנמל שאליו יחובר השרת לצורך קבלת בקשות.

        // יצירת רשימות לאחסון שמות משתמשים, סיסמאות ומזהים ייחודיים.
        var usernames = new List<string>();  // רשימה לשמירת שמות המשתמשים הרשומים.
        var passwords = new List<string>();  // רשימה לשמירת הסיסמאות.
        var userIds = new List<string>();  // רשימה לשמירת המזהים הייחודיים של המשתמשים.
        string userId = "";  // משתנה לאחסון מזהה המשתמש הנוכחי שנכנס.

        var server = new Server(port);  // יצירת אובייקט של שרת שמאזין בנמל הנבחר.

        Console.WriteLine("השרת פועל");
        Console.WriteLine($"דף הבית: http://localhost:{port}/website/pages/index.html");

        // לולאת הפעולה המרכזית של השרת, שממתינה לבקשות מהמשתמשים.
        while (true)
        {
            (var request, var response) = server.WaitForRequest();  // קבלת הבקשה מהמשתמש והתגובה אליה.

            Console.WriteLine($"התקבלה בקשה במסלול: {request.Path}");

            // בדיקה אם הנתיב שמצוין קיים כקובץ במערכת.
            if (File.Exists(request.Path))
            {
                var file = new File(request.Path);
                response.Send(file);  // שליחת הקובץ כתגובה למשיב.
            }
            // אם הנתיב לא מורה על קובץ, ואם מדובר בבקשת HTML, שולחים דף 404.
            else if (request.ExpectsHtml())
            {
                var file = new File("website/pages/404.html");
                response.SetStatusCode(404);  // קביעת מצב הסטטוס כאבדוק.
                response.Send(file);  // שליחת דף השגיאה 404.
            }
            else
            {
                try
                {
                    // טיפול בבקשות להרשמה.
                    if (request.Path == "signup")
                    {
                        (string username, string password) = request.GetBody<(string, string)>();

                        usernames.Add(username);  // הוספת שם המשתמש לרשימה.
                        passwords.Add(password);  // הוספת הסיסמא לרשימה.
                        userIds.Add(Guid.NewGuid().ToString());  // יצירת מזהה ייחודי חדש והוספתו לרשימה.

                        Console.WriteLine($"משתמש חדש נרשם: {username}, {password}");
                    }
                    // טיפול בבקשות להתחברות.
                    else if (request.Path == "login")
                    {
                        (string username, string password) = request.GetBody<(string, string)>();
                        bool foundUser = false;

                        for (int i = 0; i < usernames.Count; i++)
                        {
                            if (username == usernames[i] && password == passwords[i])
                            {
                                foundUser = true;
                                userId = userIds[i];  // משחק לזהות המשתמש שמתחבר.
                                break;
                            }
                        }

                        response.Send((foundUser, userId));  // שליחת תשובה האם נמצא משתמש.
                    }
                    else
                    {
                        response.SetStatusCode(405);  // אם השיטה אינה מורשית, מצב סטטוס 405.
                    }
                }
                catch (Exception exception)
                {
                    Log.WriteException(exception);  // אם מתרחשת תקלה, לוג אותה.
                }
            }

            response.Close();  // סוגר את הקשר לאחר שליחת התגובה.
        }
    }
}
