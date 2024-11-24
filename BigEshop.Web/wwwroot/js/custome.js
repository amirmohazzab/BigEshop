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





function Like(url) {
    fetch(url, { method: "POST" }).then(res => res.json())
        .then(res => {
            if (res.status == 100) {
                Swal.fire({
                    title: "عملیات موفق",
                    text: res.message,
                    icon: "success"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    } else {
                       
                    }
                })
            } else {
                Swal.fire({
                    title: "عملیات نا موفق",
                    text: res.message,
                    icon: "error"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    } else {
                       
                    }
                })
            }
        })
}

function Dislike(url) {
    fetch(url).then(res => res.json())
        .then(res => {
            if (res.status == 100) {
                Swal.fire({
                    title: "عملیات موفق",
                    text: res.message,
                    icon: "success"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    } else {
                        setTimeout(() => {
                            location.reload();
                        }, 1000);
                    }
                })
            } else {
                Swal.fire({
                    title: "عملیات نا موفق",
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
        })
}

//function Like(url){

//    $.ajax({
//        url: url,
//        contentType: 'application/json',
//        data: requestInJSONFormat,
//        headers: { 'Access-Control-Allow-Origin': '*' },
//        dataType: 'json',
//        type: 'POST',
//        async: false,
//        success: function (Data) {...}
//});
//}

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

function showCreateProductAnswerToQuestionModal(questionId) {

    fetch(`/product/CreateAnswerToQuestion/${questionId}`)
        .then(res => res.text())
        .then(data => {

            $("#large-modal-title").html("پاسخ به پرسش");
            $("#large-modal-body").html(data);
            $("#large-modal").modal('show');

        })
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

function showContactModal() {

    fetch(/Home/Chat)
        .then(res => res.text())
        .then(data => {

            $("#large-modal-title").html("افزودن نظر به محصول");
            $("#large-modal-body").html(data);
            $("#large-modal").modal('show');

        })
}

