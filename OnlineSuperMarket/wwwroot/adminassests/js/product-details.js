var overlayProduct = document.querySelector(".overlayProduct");
var createProductForm = document.querySelector(".createProduct");
var editProductBtn = document.querySelector(".editBtn");

function visibleProductForm() {
  createProductForm.classList.toggle("visible");
  overlayProduct.classList.toggle("active");
}

overlayProduct.onclick = function () {
  visibleProductForm();
}

editProductBtn.onclick = function () {
  console.log("Click")
  visibleProductForm();
}