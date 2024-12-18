using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int port = 5000;
        
        
        var usernames = new List<string>();
        var passwords = new List<string>();
        var userIds = new List<string>();
        string userId = "";
        var server = new Server(port);

        Console.WriteLine("The server is running");
        Console.WriteLine($"Main Page: http://localhost:{port}/website/pages/index.html");

        while (true)
        {
            (var request, var response) = server.WaitForRequest();

            Console.WriteLine($"Received a request with the path: {request.Path}");

            if (File.Exists(request.Path))
            {
                var file = new File(request.Path);
                response.Send(file);
            }
            else if (request.ExpectsHtml())
            {
                var file = new File("website/pages/404.html");
                response.SetStatusCode(404);
                response.Send(file);
            }
            else
            {
                try
                {
                    if (request.Path == "signup")
                    {
                    
                        (string username, string password) = request.GetBody<(string, string)>();

                        usernames.Add(username);
                        passwords.Add(password);
                        userIds.Add(Guid.NewGuid().ToString()); 

                        Console.WriteLine($"New user registered: {username}, {password}");
                    }
                    else if (request.Path == "login")
                    {

                        (string username, string password) = request.GetBody<(string, string)>();
                        bool foundUser = false;

                        for (int i = 0; i < usernames.Count; i++)
                        {
                            if (username == usernames[i] && password == passwords[i])
                            {
                                foundUser = true;
                                userId = userIds[i]; 
                                break;
                            }
                        }

                        
                        response.Send((foundUser, userId));
                    }
                   
                    else
                    {
                        response.SetStatusCode(405);
                    }
                }
                catch (Exception exception)
                {
                    Log.WriteException(exception); 
                }
            }

            response.Close(); 
        }
    }
}