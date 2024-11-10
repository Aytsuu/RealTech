var username;
var email;
var dateofbirth;
const passwordRegex = "^(?!.* ).{6,20}$"

document.addEventListener('DOMContentLoaded', function () {
    $(".sec1-container").addClass('active');
}) 

function returnBorder(field) {
    field.style.borderColor = "#ccc";
}

$().ready(function () {

    $("#next-fpUser").click(function () {
        username = $("#fp-username").val();

        $.post('../Home/ValidateUser', {
            user: username
        }, function (data) {
            if (data[0].mess == 1) {
                $(".sec1-container").removeClass('active');
                $(".sec2-container").addClass('active');
            }
            else if (data[0].mess == 0) { 
                document.getElementById("fp-username").style.borderColor = "red";
            }
        });
        
    });

    $("#next-fpEmail").click(function () {
        email = $("#fp-email").val();

        $.post('../Home/FPEmailChecker', {
            user: username,
            email: email
        }, function (data) {
            if (data[0].mess == 1) {
                $(".sec2-container").removeClass('active');
                $(".sec3-container").addClass('active');
            }
            else if (data[0].mess == 0) {
                document.getElementById("fp-email").style.borderColor = "red";
            }
        });
        
    });

    $("#next-fpDob").click(function () {
        dateofbirth = $("#fp-dob").val();
        $.post('../Home/FPDoBChecker', {
            user: username,
            email: email,
            dob: dateofbirth
        }, function (data) {
            if (data[0].mess == 1) {
                $(".sec3-container").removeClass('active');
                $(".sec4-container").addClass('active');
            }
            else if (data[0].mess == 0) {
                document.getElementById("fp-dob").style.borderColor = "red";
            }
        });
    });

    $("#finish-fpNewPass").click(function () {
        var newpass = $("#fp-newpass").val();
        var confpass = $("#fp-confirmpass").val();

        if (confpass == newpass && newpass.match(passwordRegex)) {
            $.post('../Home/FPChangePass', {
                user: username,
                newpass: newpass
            }, function (data) {
                if (data[0].mess == 1) {
                    $(".sec4-container").removeClass('active');
                    $(".successNotif").addClass('active');
                }
            });
        }
        else {
            document.getElementById("fp-newpass").style.borderColor = "red";
            document.getElementById("fp-confirmpass").style.borderColor = "red";
        }

    });

    $("#backToSignIn").click(function () {
        window.location.href = "https://localhost:44352/Home/SignInView";
    });

    $("#prev-fpUser").click(function () {
        window.location.href = "https://localhost:44352/Home/SignInView";
    });


    $("#prev-fpEmail").click(function () {
        $(".sec1-container").addClass('active');
        $(".sec2-container").removeClass('active');
    });
    $("#prev-fpDob").click(function () {
        $(".sec2-container").addClass('active');
        $(".sec3-container").removeClass('active');
    });

    $("#prev-fpNewPass").click(function () {
        $(".sec3-container").addClass('active');
        $(".sec4-container").removeClass('active');
    });

});