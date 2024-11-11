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