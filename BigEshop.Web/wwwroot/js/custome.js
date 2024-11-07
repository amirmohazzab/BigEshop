function ShowCreateProductComment(productId) {
    fetch(`/product/CreateProductComment/${productId}`)
        .then(data => {
            console.log(data);
        })
}