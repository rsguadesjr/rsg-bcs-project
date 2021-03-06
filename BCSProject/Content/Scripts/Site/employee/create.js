﻿$(document).ready(function () {

    //initialization
    loadCountries();

    $("form").on("submit", function (e) {
        console.log("submit");
        if ($(this).valid()) {
            console.log("valid");
            login();
        }
        return false;
    });

    $("#country").change(function () {
        loadStates($("#country").val());
    });
});

function loadCountries() {
    $.ajax({
        url: "https://restcountries.eu/rest/v2/all",
        success: function (data) {
            $("#country").find("option").remove();
            var option = "";
            $.each(data, function (i, item) {
                option += "<option value=" + item.alpha2Code + ">" + item.name + "</option>";
            });
            $("#country").append(option);
        }
    });
}

function loadStates(country) {
    //filter only if us or ph
    switch (country) {
        case "PH":
            console.log("Load PH");
            break;
        case "US":
            console.log("Load US");
            break;
    }

}

function submitForm() {
    var employee = {
        employeeNo: 114,
        firstname: $("#firstName").val(),
        lastname: $("#lastName").val(),
        age: $("#age").val(),
        birthday: $("#birthday").val(),
        gender: $("#gender").val(),
        address: $("#address").val(),
        country: $("#country").val(),
        state: $("#state").val(),
        phoneNo: $("#phone").val(),
        dateHired: $("#dateHired").val(),
        dateResigned: $("#dateResigned").val(),
        hobbies: hobbies(),
        interest: interests()
    };
    $.ajax({
        url: $("#WebApiLink").val() + "api/employees",
        type: "POST",
        data: JSON.stringify(employee),
        contentType: "application/json",
        success: function (e) {
            console.log("success");
            console.log(e);
            window.location.href = "/employees";
        },
        complete: function (e) {
            console.log("complete");
            console.log(e);
        },
        error: function (xhr) {
            console.log("error:");
            console.log(xhr);
        }
    });
}

function hobbies() {
    var hobbyObj = [];
    var hobbies = $("#hobby").val();
    hobbies = hobbies.split(",");


    if (hobbies) {
        for (var i = 0; i < hobbies.length; i++) {
            hobbyObj.push({ hobbyName: hobbies[i] });
        }
    }
    return hobbyObj;
}
function interests() {
    var interestObj = [];
    var interests = $("#interest").val();
    interests = interests.split(",");


    if (interests) {
        for (var i = 0; i < interests.length; i++) {
            interestObj.push({ interestName: interests[i] });
        }
    }
    return interestObj;
}


