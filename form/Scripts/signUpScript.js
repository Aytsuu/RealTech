var validUser = 0;
var validEmail = 0;
var validNumber = 0;
var validPass = 0;
const usernameRegex = /^[a-zA-Z0-9]+$/;
const emailRegex = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
const passwordRegex = "^(?!.* ).{6,20}$"
function validateUsername() {
    var username = $("#username").val();

    //Username Validation
    $.post('../Home/ValidateUser', {
        user: username
    }, function (data) {
        if (data[0].mess == 1) {
            document.getElementById("username").style.borderColor = "red";
            validUser = 0;
        }
        else if (data[0].mess == 0) {
            document.getElementById("username").style.borderColor = "rgba(46,82,102,0.5)";
            if (username.match(usernameRegex)) validUser = 1;
            if (!username.match(usernameRegex) && username.length != 0) document.getElementById("username").style.borderColor = "red";
        }
    });

}
function validateEmail() {
    var email = $("#email").val();

    //Email Validation
    $.post('../Home/ValidateEmail', {
        email: email
    }, function (data) {
        if (data[0].mess == 1) {
            document.getElementById("email").style.borderColor = "red";
            validEmail = 0;
        }
        else if (data[0].mess == 0) {
            document.getElementById("email").style.borderColor = "rgba(46,82,102,0.5)";
            if (email.match(emailRegex)) validEmail = 1;
            if (!email.match(emailRegex) && email.length != 0) document.getElementById("email").style.borderColor = "red";
        }
    });
}
function validateNumber() {
    var number = $("#number").val();

    //Number Validation
    $.post('../Home/ValidateNumber', {
        number: number
    }, function (data) {
        if (data[0].mess == 1) {
            document.getElementById("number").style.borderColor = "red";
            validNumber = 0;
        }
        else if (data[0].mess == 0) {
            document.getElementById("number").style.borderColor = "rgba(46,82,102,0.5)";
            if (number.length > 0) validNumber = 1;
        }
    });
}

function passwordConfirmation() {

    var password = $("#password").val();
    var confirmPass = $("#confirm-pass").val();

    if (confirmPass != password) {
        document.getElementById("confirm-pass").style.borderColor = "red";
        validPass = 0;
    }
    else if (confirmPass == password) {
        document.getElementById("confirm-pass").style.borderColor = "rgba(46,82,102,0.5)";
        validPass = 1;
    }
}

function showConfirmation() {
    if ($("#password").val().match(passwordRegex)) {
        $("#confirm-pass").show()
    }
    else {
        $("#confirm-pass").hide()
        document.getElementById("confirm-pass").style.borderColor = "rgba(46,82,102,0.5)";
    }
}


$().ready(function () {
    $(".sign-up").click(function () {

        var username = $("#username").val();
        var email = $("#email").val();
        var number = $("#number").val();
        var password = $("#password").val();

        if ((validUser + validEmail + validNumber + validPass) == 4) {
            $.post('../Home/AddAccount', {
                user: username,
                email: email,
                number: number,
                pass: password
            }, function (data) {
                localStorage.setItem('username', username);
                localStorage.setItem("signed-in", "yes");
                window.location.href = "https://localhost:44352/Home/CreateProfile";
            });
        }
    });
});
