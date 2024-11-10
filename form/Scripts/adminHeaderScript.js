$().ready(function () {

    $("#accountBar").click(function () {

        var clickedAcc = $(".account-dropdown").val();

        if (clickedAcc == 0) {
            $(".account-dropdown").addClass('active');
            $(".account-dropdown").val('1');
        }
        else {
            $(".account-dropdown").removeClass('active');
            $(".account-dropdown").val('0');
        }
    });

    $("#logout").click(function () {
        window.location.href = "https://localhost:44352/Home/AdminSignIn";
    })
});