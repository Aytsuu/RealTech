function cart(x) {

    if (checker == "yes") {
        var username = localStorage.getItem("username");
        var row = x.closest('tr');
        var cells = row.querySelectorAll("td");
        var productId = cells[0].querySelector('label').innerText;
        var quantity = cells[6].querySelector('label').innerText;

        $.post('../Home/AddToCart', {
            user: username,
            prodID: productId,
            quantity: quantity,
        }, function (data) {
            if (data[0].mess == 1) popupNotif();
        });
    }
    else {
        window.location.href = "https://localhost:44352/Home/SignInView";
    }
}

function popupNotif() {
    setTimeout(() => {
        setTimeout(() => {
            $(".popup-bg").addClass('active');
            $(".cart-notif").addClass('active');
        });

        setTimeout(() => {
            $(".popup-bg").removeClass('active');
            $(".cart-notif").removeClass('active');
        },1600);
    });
}

function add(x) {

    var row = x.closest('tr');
    var cells = row.querySelectorAll("td");
    var index = x.closest('td').cellIndex;
    var quantity = cells[index].querySelector('label');
    quantity.innerHTML = parseInt(quantity.innerHTML) + 1;
}

function minus(x) {
    var row = x.closest('tr');
    var cells = row.querySelectorAll("td");
    var index = x.closest('td').cellIndex;
    var quantity = cells[index].querySelector('label');

    if (parseInt(quantity.innerHTML) > 1) {
        quantity.innerHTML = parseInt(quantity.innerHTML) - 1;
    }
}

