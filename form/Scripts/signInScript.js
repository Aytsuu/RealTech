function returnBorderColor() {
    document.getElementById("username").style.borderColor = "rgba(0,0,0,0.5)";
    document.getElementById("password").style.borderColor = "rgba(0,0,0,0.5)";
}

function returnBorderColor1() {
    document.getElementById("adminUser").style.borderColor = "#aaa";
    document.getElementById("adminPass").style.borderColor = "#aaa";
}

$().ready(function () {

    //Customer Login
    $(".sign-in").click(function () {
        customerLogin();
    });

    $("#username").keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            customerLogin();
        }
    })

    $("#password").keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            customerLogin();
        }
    })

    //Admin Login
    $("#logIn").click(function () { 
        if ($("#adminUser").val() == "queenie" && $("#adminPass").val() == "123123") {
            window.location.href = "https://localhost:44352/Home/AdminProductsList";
        }
        else {
            document.getElementById("adminUser").style.borderColor = "red";
            document.getElementById("adminPass").style.borderColor = "red";
        }
    });

    $("#adminUser").keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            adminLogin();
        }
    })

    $("#adminPass").keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            adminLogin();
        }
    })

});

function customerLogin() {
    var username = $("#username").val();
    var password = $("#password").val();

    if (username.length > 0 && password.length > 0) {
        $.post('../Home/SignInDBConnection', {
            user: username,
            pass: password
        }, function (data) {
            if (data[0].mess == 2) {
                localStorage.setItem("signed-in", "yes");
                localStorage.setItem('username', username);
                window.location.href = "https://localhost:44352/Home/CreateProfile";
            }
            else if (data[0].mess == 1) {
                localStorage.setItem("signed-in", "yes");
                localStorage.setItem('username', username);
                window.location.href = "https://localhost:44352/Home/CustomerView";
            }
            else if (data[0].mess == 0) {
                document.getElementById("username").style.borderColor = "red";
                document.getElementById("password").style.borderColor = "red";
            }
        });
    }
    else {
        document.getElementById("username").style.borderColor = "red";
        document.getElementById("password").style.borderColor = "red";
    }
}

function adminLogin() {
    if ($("#adminUser").val() == "queenie" && $("#adminPass").val() == "123123") {
        window.location.href = "https://localhost:44352/Home/AdminProductsList";
    }
    else {
        document.getElementById("adminUser").style.borderColor = "red";
        document.getElementById("adminPass").style.borderColor = "red";
    }
}