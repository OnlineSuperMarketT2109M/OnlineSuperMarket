var overlayProduct = document.querySelector(".overlayProduct");
var createProductForm = document.querySelector(".createProduct");
var editProductBtn = document.querySelector(".editBtn");
var miniCart = document.querySelector(".miniCart");

var desImage1 = document.querySelector(".desImage1");
var desImage2 = document.querySelector(".desImage2");
var desImage3 = document.querySelector(".desImage3");
var desImage4 = document.querySelector(".desImage4");
var desImage = document.querySelectorAll(".desImage");

/*desImage2.onclick = function () {
    if (desImage.classList.contains("active")) {
        this.desImage.classList.remove("active");
        desImage2.classList.add("active");
    }
}*/

window.addEventListener("scroll", function () {
    if (window.scrollY > 900) {
        miniCart.classList.add("visible");
    } else {
        miniCart.classList.remove("visible");
    }
})

/*function visibleProductForm() {
    createProductForm.classList.toggle("visible");
    overlayProduct.classList.toggle("active");
}

overlayProduct.onclick = function () {
    visibleProductForm();
}

editProductBtn.onclick = function () {
    console.log("Click")
    visibleProductForm();
}*/


var overlay = document.querySelector("#overlay");
var writeComment = document.querySelector(".productComment--heading button");
var productCommentForm = document.querySelector(".productCommentForm");
var productCommentFormClose = document.querySelector(".productCommentForm--heading--close");


function activeOverlay() {
    productCommentForm.classList.toggle("visible");
    overlay.classList.toggle("active");
}


writeComment.onclick = function () {
    activeOverlay();
}

overlay.onclick = function () {
    activeOverlay();
}

productCommentFormClose.onclick = function () {
    activeOverlay();
}