$(document).ready(function () {
    var username = localStorage.getItem('username');
    $("#username").val(username);

    $("#home").click(function () {
        localStorage.clear();
        window.location.href = "https://localhost:44352/Home/CustomerView";
    });
});
