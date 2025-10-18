function loginAccount(userInput) {
    $.ajax({
        type: "POST",
        url: "/Account/LoginToSystem",
        data: userInput,
        dataType: 'json',
        success: function (res) {
            var x = 3;
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