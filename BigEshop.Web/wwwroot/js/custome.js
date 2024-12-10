
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

function OnSuccessCreateProductQuestion(res) {

    if (res.status == 100) {
        //location.href = res.url;
        Swal.fire({
            title: "پرسش شما با موفقیت ثبت شد",
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

function OnSuccessCreateAnswerToQuestion(result) {

    if (result && result.status == 100) {
        Swal.fire({
            title: "عملیات موفق",
            text: result.message,
            icon: "success"
        });
    } else {
        Swal.fire({
            title: "خطا",
            text: result.message,
            icon: "error"
        });
    }

    setTimeout(() => {
        $("#large-modal").modal('hide');
        location.reload();
    }, 2000)
}

function OnSuccessCreateWeblogCommentAnswer(res) {

    if (res.status == 100) {
        //location.href = res.url;
        Swal.fire({
            title: "کامنت شما با موفقیت ثبت شد",
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

function showCreateWeblogCommentAnswerModal(url) {

    fetch(url).then(res => res.text()).then(data => {

        $("#large-modal-title").html("پاسخ به کامنت ارسال شده");
        $("#large-modal-body").html(data);
        $("#large-modal").modal('show');

    })
}

function showCreateProductAnswerModal(url) {

    fetch(url).then(res => res.text()).then(data => {

        $("#large-modal-title").html("پاسخ به پرسش مطرح شده");
        $("#large-modal-body").html(data);
        $("#large-modal").modal('show');

    })
}

function showCategorizedProduct(categoryId) {

    fetch(`/Home/ShowCategorizedProduct/${categoryId}`)
        .then(res => res.text())
        .then(data => {
            $("#main-body-product").html(data);
        })
}

function likeToProductComment(url) {

    fetch(url).then(res => res.json()).then(data => {
        location.reload()
    })
}

function dislikeToProductComment(url) {

    fetch(url).then(res => res.json()).then(data => {
        location.reload()
    })
}

function likeToProductAnswer(url) {

    fetch(url).then(res => res.json()).then(data => {
        location.reload()
    })
}

function dislikeToProductAnswer(url) {

    fetch(url).then(res => res.json()).then(data => {
        location.reload()
    })
}

function showContactModal(url) {
    fetch(url).then(res => res.text()).then(data => {

        $("#small-modal-title").html("لطفا پرسش خود را مطرح نمایید");
        $("#small-modal-body").html(data);
        $("#small-modal").modal('show');
    })
}

function addProductToOrder(productId, colorId) {
    fetch(`/Order/AddToOrder/${orderDetailId}`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        Body: JSON.stringify({ productId: productId, colorId: colorId})
    })
        .then(res => res.json())
        .then(data => {
            location.href = "/basket";
        })
}