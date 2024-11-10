
function remove(product) {
    var row = product.closest('tr');
    var cells = row.querySelectorAll('td');
    var prodName = cells[2].querySelector('label').innerText;
    var prodId = cells[0].querySelector('label').innerText;
    var username = $("#username-text").val();

    $(".popup-bg").addClass('active');
    $(".del-notif").addClass('active');
    $("#prodName").html(prodName);

    $("#yes").click(function () {
        $.post('../Home/DeleteCartProduct', {
            prodid: prodId,
            user: username
        }, function (data) {
            if (data[0].mess == 1) window.location.href = "https://localhost:44352/Home/CustomerViewCart";
        });
    });

    $("#cancelDel").click(function () {
        $(".popup-bg").removeClass('active');
        $(".del-notif").removeClass('active');
    });

}
    

