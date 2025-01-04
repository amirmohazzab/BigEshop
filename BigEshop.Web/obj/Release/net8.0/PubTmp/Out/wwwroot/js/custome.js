
function OnSuccessCreateProductComment(res) {

    if (res.status == 100) {
        //location.href = res.url;
        Swal.fire({
            title: "کامنت با موفقیت ثبت شد",
            icon: "success"
        }).then(() => {
            setTimeout(() => {
                location.reload();
            }, 500)
        })
    } else {
        Swal.fire({
            title: "خطا",
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

function OnSuccessCreateWeblogComment(res) {

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
        Swal.fire({
            title: "علاقمندی شما ثبت شد",
            icon: "success"
        }).then(() => {
            setTimeout(() => {
                location.reload();
            }, 500)
        })
    })
}

function dislikeToProductComment(url) {

    fetch(url).then(res => res.json()).then(data => {
        Swal.fire({
            title: "عدم علاقمندی شما ثبت شد",
            icon: "success"
        }).then(() => {
            setTimeout(() => {
                location.reload();
            }, 500)
        })
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
            location.href = '/Cart';
        })
}

function addToWeblogVisit(weblogId) {
    fetch(`/Home/AddToWeblogVisit/${weblogId}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
        })
}

function addToFavorite(productId) {

    fetch(`/Product/AddToFavorite/${productId}`)
        .then(res => res.json()).then(data => {
            Swal.fire({
                title: "علاقمندی شما ثبت شد",
                icon: "success"
            }).then(() => {
                setTimeout(() => {
                    location.reload();
                }, 500)
            })
        })
}

function addToProductVisit(productId) {
    fetch(`/product/AddToProductVisit/${productId}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
        })
}

function fillPageId(pageId) {
    $("#Page").val(pageId);
    $("#filter-search").submit();
}

function deleteAdres(id) {
    fetch(`/UserPanel/Adres/Delete/${id}`)
        .then(res => res.json())
        .then(result => {
            if (result.status == 100) {
                setTimeout(() => {
                    location.reload();
                }, 500)
            }
            else {
                Swal.fire({
                    text: result.message,
                    icon: "error"
                })
            }
        })
}

function showEditAdresModal(id) {
    fetch(`/UserPanel/Adres/Edit/${id}`)
        .then(res => res.text()).then(data => {

        $("#large-modal-title").html("ویرایش آدرس شما");
        $("#large-modal-body").html(data);
        $("#large-modal").modal('show');
    })
}

function OnSuccessEditAdres(res) {

    if (res.status == 100) {
        
        setTimeout(() => {
            location.reload();
        }, 500)
        
    } else {
        Swal.fire({
            text: res.message,
            icon: "error"
        })
    }
}

function confirmedProductComment(url) {
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

function rejectedProductComment(url) {
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

function confirmedWeblogComment(commentId) {
    fetch(`/WeblogComments/ConfirmWeblogComment/${commentId}`)
        .then(res => res.json())
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

function rejectedWeblogComment(commentId) {
    fetch(`/WeblogComments/RejectWeblogComment/${commentId}`)
        .then(res => res.json())
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

function deleteOrderDetails(orderDetail) {
    fetch(`/Order/DeleteOrderDetails/${orderDetail}`)
        .then(res => res.json())
        .then(data => {
            location.reload();
        })
}

function deleteFromFavorites(productId) {

    fetch(`/UserPanel/Home/DeletefromFavorites/${productId}`)
        .then(res => res.json())
        .then(() => {
            setTimeout(() => {
                location.reload();
            }, 500)
        })
}

function deleteFromVisits(productId) {

    fetch(`/UserPanel/Home/DeletefromVisits/${productId}`)
        .then(res => res.json())
        .then(() => {
            setTimeout(() => {
                location.reload();
            }, 500)
        })
}
