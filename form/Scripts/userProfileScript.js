document.addEventListener('DOMContentLoaded', function () {
    $("#editProfile").addClass('active');
});
$().ready(function () {
    $("#editProfile").click(function () {
        $(".editChoices").addClass('active')
        $("#editProfile").addClass ('fade');
        $(".inputFields input").attr("disabled", false);
        $("select").attr("disabled", false);
    });

    $("#cancel").click(function () {
        $(".editChoices").removeClass('active')
        $("#editProfile").removeClass('fade');
        $("#editProfile").addClass('active');
        $(".inputFields input").attr("disabled", true);
        $("select").attr("disabled", true);
    });
});