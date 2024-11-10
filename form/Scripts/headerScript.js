const username = localStorage.getItem('username');
const checker = localStorage.getItem('signed-in');

document.addEventListener('DOMContentLoaded', function () {
    $.post('../Home/UserCart', {
        user: username
    }, function (data) { });     
});

function checkLoggedIn() {
    if (checker == "yes") {
        window.location.href = "https://localhost:44352/Home/CustomerViewCart";
    }
    else {
        window.location.href = "https://localhost:44352/Home/SignInView";
    }
}

$().ready(function () {
    if (checker == "yes") {
        $("#username-text").val(username);
    }
    else {
        $("#username-text").val("Sign In");
    }
    


    $("#accountBar").click(function () {

        if (checker == "yes") {
            var clickedAcc = $(".account-dropdown").val();

            if (clickedAcc == 0) {
                $(".account-dropdown").addClass('active');
                $(".account-dropdown").val('1');
            }
            else {
                $(".account-dropdown").removeClass('active');
                $(".account-dropdown").val('0');
            }
        }
        else {
            window.location.href = "https://localhost:44352/Home/SignInView";
        }
    });

    $("#logout").click(function () {
        localStorage.clear(); 
        window.location.href = "https://localhost:44352/Home/CustomerView";
    })

    $("#profile").click(function () {
        window.location.href = "https://localhost:44352/Home/UserProfile";
    });


    //Search engine
    $("#searchBtn").click(function () {
        searchProduct();
    });

    $("#search").keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            searchProduct();
        }
    })

});

function searchProduct() {
    var search = $("#search").val();

    if (search.length > 0) {
        $.post('../Home/SignalSearchBar', {
            key: search
        }, function (data) {
            if (data[0].mess == 1) window.location.href = "https://localhost:44352/Home/CustomerViewProducts";
        });
    }
}

