var inputFile = document.getElementById("prod2");
var fileName = document.getElementById("file-name");

inputFile.addEventListener('change', function (event) {
    var uploadedImage = event.target.files[0].name;
    fileName.innerHTML = uploadedImage;
})


function editProduct(product) {
    var row = product.closest('tr');
    var cells = row.querySelectorAll('td');
    var prodId = cells[0].querySelector('label').innerText;

    $.post('../Home/EditProductSession', {
        prodid: prodId
    }, function (data) {
        if (data[0].mess == 1) window.location.href = "https://localhost:44352/Home/AdminEditProduct";
    });
}

function deleteProduct(product) {
    var row = product.closest('tr');
    var cells = row.querySelectorAll('td');
    var prodName = cells[2].querySelector('label').innerText;
    var prodId = cells[0].querySelector('label').innerText;

    $(".popup-bg").addClass('active');
    $(".del-notif").addClass('active');
    $("#prodName").html(prodName);

    $("#yes").click(function () {

        $.post('../Home/DeleteProduct', {
        prodid: prodId
        }, function (data) {
            if (data[0].mess == 1) window.location.href = "https://localhost:44352/Home/AdminProductsList";
        });
    });

    $("#cancel").click(function () {
        $(".popup-bg").removeClass('active');
        $(".del-notif").removeClass('active');
    });
}

$().ready(function () {
    $(".addprod-btn").click(function () {
        $(".transparent-bg").addClass('active')
        $(".add-container").addClass('active')
    });

    $(".back-btn").click(function () {
        $(".transparent-bg").removeClass('active')
        $(".add-container").removeClass('active')
        fileName.innerHTML = 'None';
        fileName1.innerHTML = 'None';
    });
});

