
function fillPageId(pageId) {
	$("#Page").val(pageId);
	$("#filter-search").submit();
}

function confirmDelete(url, e) {

	e.preventDefault();

	Swal.fire({
		text: "آیا از انجام این عملیات مطمین هستید؟",
		icon: "question",
		showCancelButton: true,
		confirmButtonColor: "#3085d6",
		cancelButtonColor: "#d33",
		confirmButtonText: "بله",
		cancelButtonText: "خیر"
	}).then((result) => {
		if (result.isConfirmed) {
			location.href = url;
		}
	});

}