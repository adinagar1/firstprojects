import { send } from "../utilities";
'send'
'utilities'

let usernameInput = document.querySelector("#usernameInput") as HTMLInputElement;
// מחפש באובייקט ה-HTML את ה-<input> שמכיל את האיד של 'usernameInput' ומקצה לו משתנה מסוג 'HTMLInputElement'

let passwordInput = document.querySelector("#passwordInput") as HTMLInputElement;
// מחפש באובייקט ה-HTML את ה-<input> שמכיל את האיד של 'passwordInput' ומקצה לו משתנה מסוג 'HTMLInputElement'

let loginButton = document.querySelector("#loginButton") as HTMLInputElement;
// מחפש באובייקט ה-HTML את ה-<button> שמכיל את האיד של 'loginButton' ומקצה לו משתנה מסוג 'HTMLInputElement'

loginButton.onclick = async function () {
    // אירוע לחיצה על כפתור הכניסה, מבצע פעולה בצורה אסינכרונית

    let [userFound, userId] = await send("login", [usernameInput.value, passwordInput.value]) as [boolean, string];
    // שולח בקשה לשרת עם שם הפעולה "login" ומשתמש ב-username וב-password שהוזנו, מחזיר ערכים בוליאניים ומזהה משתמש. 

    console.log("User found: " + userFound);
    // מודפס בתצוגה "User found: true" או "User found: false" בהתאם לתשובת השרת

    if (userFound) {
        localStorage.setItem("userId", userId);
        location.href = "\website\pages\index.html"
        // אם המשתמש נמצא, שומר את ה-Id שלו ב-localStorage ומבצע הפניה לדף הבית
    } else {
        alert("Invalid username or password!");
        // אם המשתמש לא נמצא, מציג תיבת הודעה 
    }
}
