$(document).ready(function () {
    $("#email-display").text(email);
    $("#username-display").text(username);
    $("#logout").click(function (e) { 
        e.preventDefault();
        localStorage.clear();
        window.location.href = "/login";
    });
});