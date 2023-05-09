const loginForm = document.querySelector(".loginForm");
const overlay = document.querySelector("#overlay");
const signIn = document.querySelector(".headerTop--list--signin");
const closeLoginForm = document.querySelector("#closeLoginForm");

function displayLoginForm() {
    loginForm.classList.toggle("active");
    overlay.classList.toggle("active");
}

signIn.onclick = function () {
    displayLoginForm();
}

overlay.onclick = function () {
    displayLoginForm();
}

closeLoginForm.onclick = function () {
    displayLoginForm();
}