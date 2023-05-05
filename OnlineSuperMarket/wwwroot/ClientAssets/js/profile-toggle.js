var profileInfo = document.querySelector(".groupInfomation");
var profilePassword = document.querySelector(".groupChangepass");
var infoTag = document.querySelector(".info");
var passwordTag = document.querySelector(".password");

passwordTag.onclick = function () {
    profilePassword.classList.remove("displayNone");
    profileInfo.classList.add("displayNone");
    infoTag.classList.remove("active");
    passwordTag.classList.add("active");
}

infoTag.onclick = function () {
    profilePassword.classList.add("displayNone");
    profileInfo.classList.remove("displayNone");
    infoTag.classList.add("active");
    passwordTag.classList.remove("active");
}