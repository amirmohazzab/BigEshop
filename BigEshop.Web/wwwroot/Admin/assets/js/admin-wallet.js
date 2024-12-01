function ShowChargeWalletModal(url) {
    fetch(url).then(res => res.text()).then(data => {

        $("#large-modal-title").html("شارژکیف پول");
        $("#large-modal-body").html(data);
        $("#large-modal").modal('show');
    });
}


function OnSuccessChargeWallet(res) {
    if (res.status == 100) {
        $("#large-modal").modal('hide');

        Swal.fire({
            title: "موفق",
            text: res.message,
            icon: "success"
        })
       
    } else {
        Swal.fire({
            title: "خطا",
            text: res.message,
            icon: "error"
        })
    }
}

function changeProductColor(productColorId) {

    fetch(`/Product/ChangeProductColor/${productColorId}`)
        .then(res => res.json()).then(data => {

            document.getElementById("product-price-two").innerText = data.price
            document.getElementById("product-price-one").innerText = data.price

            var colorItems = document.getElementsByClassName('order-color-id');

            // // forEach(colorIds, (item, index) => {
            // //     item.value = data.id;
            // // });

            for (colorItem of colorItems) {
                colorItem.value = data.id;
            };
        })
}

function increaseProductQuantity(orderDetail) {
    fetch(`/order/IncreaseProductQuantity/${orderDetail}`)
        .then(res => res.json())
        .then(data => {
            location.reload();
        })
}

function decreaseProductQuantity(orderDetail) {
    fetch(`/order/DecreaseProductQuantity/${orderDetail}`)
        .then(res => res.json())
        .then(data => {
            location.reload();
            //document.getElementById("order-detail-sum").value = data.orderDetailSum
        })
}

function deleteOrderDetails(orderDetail) {
    fetch(`/Order/DeleteOrderDetails/${orderDetail}`)
        .then(res => res.json())
        .then(data => {
            location.reload();
        })
}