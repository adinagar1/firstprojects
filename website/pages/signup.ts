import { send } from "../utilities";

let usernameInput = document.querySelector("#usernameInput")as HTMLInputElement;
let passwordInput = document.querySelector("#passwordInput")as HTMLInputElement;
let signupButton = document.querySelector("#signupButton")as HTMLButtonElement;
signupButton.onclick = function(){
send("signup", [usernameInput.value, passwordInput.value]);
}
