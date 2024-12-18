import { send } from "../utilities";

let usernameInput = document.querySelector("#usernameInput") as HTMLInputElement;
let passwordInput = document.querySelector("#passwordInput") as HTMLInputElement;
let loginButton = document.querySelector("#loginButton") as HTMLInputElement;

loginButton.onclick = async function() {
    let [userFound, userId] = await send("login", [usernameInput.value, passwordInput.value]) as [boolean, string];

    console.log("User found: " + userFound);

    if (userFound) {
        localStorage.setItem("userId", userId);
        location.href="\website\pages\index.html"
    } else {
        alert("Invalid username or password!");
    }
}