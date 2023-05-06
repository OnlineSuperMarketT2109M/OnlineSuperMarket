
/*$(function () {
    console.log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    console.Log(1234);
    $('.declineBtn').click(function () {
        var orderId = @Html.Raw(Json.Serialize(Model.orderId));
        var newStatus = "Processing";
        console.log(orderId);
        console.Log(newStatus);
        $.ajax({
            type: 'POST',
            url: '/Order/ChangeOrderStatus',
            data: {
                'orderId': orderId,
                'status': newStatus
            },
            success: function (result) {

                window.location.reload();
            },
            error: function (jqXHR, textStatus, errorThrown) {

                alert('Có lỗi xảy ra khi thay đổi trạng thái đơn hàng!');
            }
        });
    });


    $('.acceptBtn').click(function () {
        var orderId = @Html.Raw(Json.Serialize(Model.orderId));
        var newStatus = "Completed";
        $.ajax({
            type: 'POST',
            url: '/Order/ChangeOrderStatus',
            data: {
                'orderId': orderId,
                'status': newStatus
            },
            success: function (result) {


                window.location.reload();
            },
            error: function (jqXHR, textStatus, errorThrown) {

                alert('Có lỗi xảy ra khi thay đổi trạng thái đơn hàng!');
            }
        });
    });
    $('.finishBtn').click(function () {
        var orderId = @Html.Raw(Json.Serialize(Model.orderId));
        var newStatus = "Canceled";
        $.ajax({
            type: 'POST',
            url: '/Order/ChangeOrderStatus',
            data: {
                'orderId': orderId,
                'status': newStatus
            },
            success: function (result) {


                window.location.reload();
            },
            error: function (jqXHR, textStatus, errorThrown) {

                alert('Có lỗi xảy ra khi thay đổi trạng thái đơn hàng!');
            }
        });
    });
});
*/

function changeOrderStatus(orderId, newStatus) {
    console.log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    $.ajax({
        type: 'POST',
        url: '/Order/ChangeOrderStatus',
        data: {
            'orderId': orderId,
            'status': newStatus
        },
        success: function (result) {
            window.location.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Có lỗi xảy ra khi thay đổi trạng thái đơn hàng!');
        }
    });
}