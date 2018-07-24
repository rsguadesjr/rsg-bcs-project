var employee = {};
$(document).ready(function () {

    //initialization
    loadCountries();
    loadEmployeeDetails();

    $("#btn-submit").on("click", function () {
        submitForm();
    });

    $("#country").change(function () {
        loadStates($("#country").val());
    });
});

function loadEmployeeDetails() {
    $.ajax({
        url: $("#WebApiLink").val() + "api/employees/" + $("#EmployeeId").val() ,
        success: function (data) {
            employee = data;
            console.log(employee);
            $("#address").val(data.address);
            $("#age").val(data.age);
            $("#birthday").val(new Date(data.birthday));
            $("#civilStatus").val(data.civilStatus);
            $("#country").val();
            $("#dateHired").val(new Date(data.dateHired));
            $("#dateResigned").val(new Date(data.dateResigned));
            $("#employeeNo").val(data.employeeNo);
            $("#firstName").val(data.firstname);
            $("#lastName").val(data.lastname);
            $("#gender").val(data.gender);
            $("#phone").val(data.phoneNo);
            $("#state").val(data.state);
            $("#hobby").tagsinput("add", data.hobbies.map(e => e.hobbyName).join());
            $("#interest").tagsinput("add", data.interests.map(e => e.interestName).join());

            console.log(data.hobbies.map(e => e.hobbyName).join());
        }
    });
}

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

            if (employee) {
                $("#country").val(employee.country);
            }
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
        complete: function (e) {
            console.log(e);
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


