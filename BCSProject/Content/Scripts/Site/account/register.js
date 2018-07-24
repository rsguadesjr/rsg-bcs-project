$(document).ready(function () {
    $("form").submit(function () {
        if ($(this).valid()) {
            $("#btn-register").prop("disabled", true);
            register();
        }
        return false;
    });
});

function register() {
    $.ajax({
        url: $("#WebApiLink").val() + "api/users",
        type: "POST",
        data: JSON.stringify({
            username: $("#Email").val(),
            password: $("#Password").val(),
            employeeId: $("#EmployeeId").val(),
            roleId: $("#RoleId").val()
        }),
        contentType: "application/json",
        complete: function (xhr) {
            if (xhr.status == 200) {
                showAlertDiag("alert-success", "Success!", "Successfully created the user.");
            }
            else {
                showAlertDiag("alert-danger", "Fail!", "Failure on creating user.");
            }
            $("#btn-register").prop("disabled", false);
        },

    });
}


