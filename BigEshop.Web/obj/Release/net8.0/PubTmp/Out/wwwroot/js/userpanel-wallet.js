function OnSuccessChargeWallet(res) {
    if (res.status == 100) {
        location.href = res.url;
    } else {
        Swal.fire({
            title: "خطا",
            text: res.message,
            icon: "error"
        })
    }
}