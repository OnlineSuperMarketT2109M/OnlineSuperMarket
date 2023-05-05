const closeBtn = document.querySelector("#closeBtn");
const notification = document.querySelector(".notification")
const closePopup = document.querySelector(".closePopup");
const popUp = document.querySelector(".newsletterPopup");
const hiddenNav = document.querySelector(".hiddenHeader");

function hiddenNotification() {
  notification.classList.add("hide");
}

function hiddenPopup() {
  popUp.classList.add("hidden");
}

closeBtn.onclick = function () {
  hiddenNotification();
}

closePopup.onclick = function () {
  hiddenPopup();
}

window.addEventListener("scroll", function () {
  if (window.scrollY > 200) {
    hiddenNav.classList.add("visible");
  } else {
    hiddenNav.classList.remove("visible");
  }
})

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
