$(document).ready(function () {
    $(".updatecartitem.quantity__minus").click(function (event) {
        event.preventDefault();
        // Code xử lý khi click vào button "Update" ở đây
        var productid = $(this).attr("data-productid");
        var routeUpdate = $(this).attr("data-route-updateCart");
        var routeCartIndex = $(this).attr("data-route-cartIndex");
        var quantity = $("#quantity-" + productid).val()
        if (parseInt(quantity) > 1) {
            var quantity = quantity - 1;
        }
        console.log(quantity);
        $.ajax({
            type: "POST",
            url: routeUpdate,
            data: {
                productid: productid,
                quantity: quantity
            },
            success: function (result) {
                window.location.href = routeCartIndex;
            }
        });
    });

    $(".updatecartitem.quantity__plus").click(function (event) {
        event.preventDefault();
        // Code xử lý khi click vào button "Update" ở đây
        var productid = $(this).attr("data-productid");
        var routeUpdate = $(this).attr("data-route-updateCart");
        var routeCartIndex = $(this).attr("data-route-cartIndex");

        var quantity = $("#quantity-" + productid).val();
        quantity = parseInt(quantity) + 1;
        console.log(quantity);
        $.ajax({
            type: "POST",
            url: routeUpdate,
            data: {
                productid: productid,
                quantity: quantity
            },
            success: function (result) {
                window.location.href = routeCartIndex;
            }
        });
    });

    $(".cart--item--quantity").on("change", function (event) {
        event.preventDefault();
        // Code xử lý khi click vào button "Update" ở đây
        var productid = $(this).attr("data-productid");
        var routeUpdate = $(this).attr("data-route-updateCart");
        var routeCartIndex = $(this).attr("data-route-cartIndex");

        var quantity = $("#quantity-" + productid).val();
        console.log(quantity);
        $.ajax({
            type: "POST",
            url: routeUpdate,
            data: {
                productid: productid,
                quantity: quantity
            },
            success: function (result) {
                window.location.href = routeCartIndex;
            }
        });
    });
});