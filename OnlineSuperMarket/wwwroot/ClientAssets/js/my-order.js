var navItem1 = document.querySelector(".rightNavbarItem1");
var navItem2 = document.querySelector(".rightNavbarItem2");
var navItem3 = document.querySelector(".rightNavbarItem3");
var navItem4 = document.querySelector(".rightNavbarItem4");
var navItem5 = document.querySelector(".rightNavbarItem5");
var navItems = document.querySelectorAll(".rightNavbar ul li");

var finished = document.querySelector("#finished");
var declined = document.querySelector("#declined");
var pending = document.querySelector("#pending");
var accepted = document.querySelector("#accepted");
var all = document.querySelector("#all");
var allStatus = document.querySelectorAll(".order--rightContent--bottom--information");


function autoRender() {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem1.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    all.classList.remove("displayNone");
}

autoRender();

navItem1.onclick = function () {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem1.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    all.classList.remove("displayNone");
}

navItem2.onclick = function () {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem2.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    accepted.classList.remove("displayNone");
}

navItem3.onclick = function () {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem3.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    pending.classList.remove("displayNone");
}

navItem4.onclick = function () {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem4.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    declined.classList.remove("displayNone");
}

navItem5.onclick = function () {
    navItems.forEach(navItem => {
        navItem.classList.remove("active");
    });
    navItem5.classList.add("active");
    allStatus.forEach(allSta => {
        allSta.classList.add("displayNone");
    });
    finished.classList.remove("displayNone");
}




accepted.onclick = function () {

}