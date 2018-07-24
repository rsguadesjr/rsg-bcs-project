$(document).ready(function () {
    $("form").submit(function () {
        if ($(this).valid()) {
            login();
        }
        return false;
    });
});

function login() {
    $.ajax({
        url: $("#WebApiLink").val() + "token",
        type: "POST",
        data: {
            username: $("#Email").val(),
            password: $("#Password").val(),
            grant_type: "password"
        },
        contentType: "application/x-www-form-urlencoded",
        success: function (response) {
            showAlertDiag("alert-success", "Access granted.", "Your have now been granted access.");
            sessionStorage.setItem("accessToken", response.access_token);
            window.location.href = "/home";
        },
        error: function (xhr) {
            console.log("error");
            showAlertDiag("alert-danger", "Access denied.", "Email/Username or password is incorrect.");
        }
    });
}