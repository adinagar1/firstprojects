import { send } from "../utilities";

let signupButton = document.querySelector("#signupButton") as HTMLButtonElement;
// מציאת כפתור ההרשמה בעזרת ה-ID ומציין אותו כ-HTMLButtonElement  
let usernameInput = document.querySelector("#usernameInput") as HTMLInputElement;
// מציאת תיבת הקלט עבור שם המשתמש בעזרת ה-ID ומציין אותה כ-HTMLInputElement  
let passwordInput = document.querySelector("#passwordInput") as HTMLInputElement;
// מציאת תיבת הקלט עבור הסיסמא בעזרת ה-ID ומציין אותה כ-HTMLInputElement  

signupButton.onclick = async function () {
    await send("signup", [usernameInput.value, passwordInput.value]);
    // השולח נתוני הרשמה לצד השרת עם ערכי שם משתמש וסיסמא וממתין לתגובה  
    alert("User registered successfully!");
    // יוצא הודעה לאחר ההרשמה המוצלחת  
}
