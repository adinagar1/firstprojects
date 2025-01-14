// כאן מתחיל הקוד שמוסיף פונקציונליות לטעינת הדפים
let signupPage = document.querySelector("#signupPage") as HTMLButtonElement;
let loginPage = document.querySelector("#loginPage") as HTMLButtonElement;

// הטיפול בכפתור ההרשמה
signupPage.addEventListener('click', function () {
    window.location.href = '/pages/signup.html';  // כשתלחץ על כפתור ההרשמה, תועבר לדף הרשמה
});

// הטיפול בכפתור הכניסה
loginPage.addEventListener('click', function () {
    window.location.href = '/pages/login.html';  // כשתלחץ על כפתור הכניסה, תועבר לדף כניסה
});