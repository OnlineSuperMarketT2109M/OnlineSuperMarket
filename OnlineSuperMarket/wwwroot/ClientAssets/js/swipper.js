
var swiper = new Swiper(".mySwiper", {
  pagination: {
    el: ".swiper-pagination",
    dynamicBullets: true,
    },
    loop: true,
    autoplay: true,
    autoplayTimeout: 1500,
    autoplayHoverPause: true,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
});

var swiper = new Swiper(".mySwiper1", {
  slidesPerView: 5,
    spaceBetween: 30,
    loop: true,
    autoplay: true,
    autoplayTimeout: 1500,
    autoplayHoverPause: true,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

var swiper = new Swiper(".mySwiper2", {
  slidesPerView: 3,
    spaceBetween: 30,
    loop: true,
    autoplay: true,
    autoplayTimeout: 1500,
    autoplayHoverPause: true,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});
