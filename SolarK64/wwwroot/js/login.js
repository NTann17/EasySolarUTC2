function token () {
    return $('input[name=__RequestVerificationToken]').val();
}
function loginAccount(userInput) {
    userInput.__RequestVerificationToken = token();
    $.ajax({
        type: "POST",
        url: "/Account/LoginToSystem",
        data: userInput,
        dataType: 'json',
        success: function (res) {
            if (res.status === 'success') {
                location.href = '/admin/dashboard';
            }
            else {
                Swal.fire({
                    icon: "error",
                    title: "Lỗi đăng nhập",
                    text: res.message
                });
            }
        },
        error: function () {
            var x = 3;
        }
    });
}

document.addEventListener("DOMContentLoaded", function () {

    //Login form
    $(document).off('submit', '#login_form');
    $(document).on('submit', '#login_form', function (e) {
        e.preventDefault();
        loginAccount({
            username: $('#username').val(),
            password: $('#password').val()
        });
    });
});