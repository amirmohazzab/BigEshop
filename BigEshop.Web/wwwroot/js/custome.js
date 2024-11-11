function OnSuccessCreateProductComment(res) {

    if (res.status == 100) {
        //location.href = res.url;
        Swal.fire({
            title: "کامنت با موفقیت ثبت شد",
            text: res.message,
            icon: "success"
        }).then(() => {
                setTimeout(() => {
                    location.reload();
                }, 1000)
            })
    } else {
        Swal.fire({
            title: "خطا",
            text: res.message,
            icon: "error"
        }).then((result) => {
            if (result.isConfirmed) {
                location.reload();
            } else {
                setTimeout(() => {
                    location.reload();
                }, 1000);
            }
        })
    }
}


