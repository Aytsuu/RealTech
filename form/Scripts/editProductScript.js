

window.addEventListener('DOMContentLoaded', function () {
    var inputFile1 = document.getElementById("prod3");

    inputFile1.addEventListener('change', function (event) {
       
        var uploadedImage = event.target.files[0].name;
        $("#file-name1").val(uploadedImage);
    })

});


$().ready(function () {
    $(".returnList-btn").click(function () {
        window.location.href = "https://localhost:44352/Home/AdminProductsList";
    });
});