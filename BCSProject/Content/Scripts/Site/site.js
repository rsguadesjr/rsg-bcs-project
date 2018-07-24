
function showAlertDiag(_class, title, message, delay = 3000) {
    $("#alert").attr("class", "alert");
    $("#alert").addClass(_class);
    $("#alert-title").text(title);
    $("#alert-msg").text(message);
    $("#alert").fadeIn().delay(3000).fadeOut("slow");
}