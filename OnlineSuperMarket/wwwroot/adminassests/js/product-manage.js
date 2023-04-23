var createProductBtn = document.querySelector(".createBtn");
var overlayProduct = document.querySelector(".overlayProduct");
var createProductForm = document.querySelector(".createProduct");
var editProductBtn = document.querySelector(".editBtn");

function visibleProductForm() {
  createProductForm.classList.toggle("visible");
  overlayProduct.classList.toggle("active");
}

createProductBtn.onclick = function () {
  visibleProductForm();
}

overlayProduct.onclick = function () {
  visibleProductForm();
}

editProductBtn.onclick = function () {
  console.log("Click")
  visibleProductForm();
}