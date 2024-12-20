import { send } from "../utilities";

let signupButton = document.querySelector("#signupButton") as HTMLButtonElement;
let usernameInput = document.querySelector("#usernameInput") as HTMLInputElement;
let passwordInput = document.querySelector("#passwordInput") as HTMLInputElement;

signupButton.onclick = async function() {
    await send("signup", [usernameInput.value, passwordInput.value]);
    alert("User registered successfully!");
}
