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


