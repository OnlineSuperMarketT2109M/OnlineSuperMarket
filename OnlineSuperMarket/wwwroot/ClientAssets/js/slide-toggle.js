console.log("aaaaaaaaaaaaaa");

$('.productList--filter--category--appliances').click(function () {

    $(".ul1").slideToggle(250);
    $(".iconPlus1").toggleClass("fa-plus");
    $(".iconPlus1").toggleClass("fa-minus");
})
$('.productList--filter--category--cameras').click(function () {
    $(".ul2").slideToggle(250);
    $(".iconPlus2").toggleClass("fa-plus");
    $(".iconPlus2").toggleClass("fa-minus");
})
$('.productList--filter--category--mobilephones').click(function () {
    $(".ul4").slideToggle(250);
    $(".iconPlus4").toggleClass("fa-plus");
    $(".iconPlus4").toggleClass("fa-minus");
})
$('.productList--filter--category--computers').click(function () {
    $(".ul3").slideToggle(250);
    $(".iconPlus3").toggleClass("fa-plus");
    $(".iconPlus3").toggleClass("fa-minus");
})

$('.productList--filter--brand').click(function () {
    $(".ul5").slideToggle(250);
    $(".iconPlus5").toggleClass("fa-plus");
    $(".iconPlus5").toggleClass("fa-minus");
})

$('.productList--filter--color').click(function () {
    $(".ul6").slideToggle(250);
    $(".iconPlus6").toggleClass("fa-plus");
    $(".iconPlus6").toggleClass("fa-minus");
})

$('.productList--filter--size').click(function () {
    $(".ul7").slideToggle(250);
    $(".iconPlus7").toggleClass("fa-plus");
    $(".iconPlus7").toggleClass("fa-minus");
})

$('.productList--filter--others').click(function () {
    $(".ul8").slideToggle(250);
    $(".iconPlus8").toggleClass("fa-plus");
    $(".iconPlus8").toggleClass("fa-minus");
})