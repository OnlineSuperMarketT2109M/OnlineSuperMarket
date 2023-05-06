$(document).ready(function () {
    $("#changeInfoForm").submit(function (event) {
        // Ngăn chặn việc tải lại trang web khi nhấp vào nút Submit
        event.preventDefault();

        // Lấy các giá trị của các trường dữ liệu trong form
        var username = $("input[name='Username']").val();
        var firstname = $("input[name='Firstname']").val();
        var lastname = $("input[name='Lastname']").val();
        var email = $("input[name='email']").val();
        var phoneNumber = $("input[name='PhoneNumber']").val();
        var address = $("input[name='Address']").val();

        // Tạo đối tượng dữ liệu để gửi đến máy chủ
        var data = {
            Username: username,
            FirstName: firstname,
            LastName: lastname,
            Email: email,
            PhoneNumber: phoneNumber,
            Address: address
        };

        // Thực hiện Ajax request
        $.ajax({
            url: "/Account/UpdateUserInfo",
            type: "POST",
            dataType: "json",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                // Xử lý phản hồi từ máy chủ nếu thành công
                alert("Update user information successfully!");
                window.location.reload();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                // Xử lý phản hồi từ máy chủ nếu lỗi
                alert("Error: " + xhr.responseText);
            }
        });
    });
});


$(document).ready(function () {
    $('#changePasswordForm').submit(function (e) {
        e.preventDefault();

        var form = $(this);
        var url = form.attr('action');
        var data = form.serialize();

        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            success: function (response) {
                alert('Password changed successfully.');
                window.location.href = '/Account/Profile'; // Redirect to profile page.
            },
            error: function (xhr, status, error) {
                var errorMessage = xhr.status + ': ' + xhr.statusText
                alert('Error - ' + errorMessage);
            }
        });
    });
});

$(document).ready(function () {
    $("#changeAvatar").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        $.ajax({
            url: "/Account/ChangeAvatar",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                window.location.href = '/Account/Profile'; // Redirect to profile page.
                // Refresh the page or update the avatar image dynamically
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseText);
                // Display an error message to the user
            }
        });
    });
});