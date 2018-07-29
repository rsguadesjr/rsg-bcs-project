$(document).ready(function () {

    $("form").on("submit",function (e) {
        if ($(this).valid()) {
            login();
        }
        return false;
    });
});

//this is for getting token
function login() {
    console.log("login...");
    $.ajax({
        url: $("#WebApiLink").val() + "api/users/login",
        type: "POST",
        data: {
            username: $("#Email").val(),
            password: $("#Password").val(),
        },
        contentType: "application/x-www-form-urlencoded",
        success: function (data) {
            console.log(data);
            $("#User_RoleName").val(data.role.roleName);
            showAlertDiag("alert-success", "Access granted.", "Your have now been granted access.");
            $("form").off("submit").submit();
        },
        error: function (xhr) {
            console.log(xhr);
            var msg = JSON.parse(xhr.responseText);
            showAlertDiag("alert-danger", "Access denied.", msg == null ? "Something went wrong." : msg.message);
        }
    });
}

//this is for getting token
function getAccessToken() {
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