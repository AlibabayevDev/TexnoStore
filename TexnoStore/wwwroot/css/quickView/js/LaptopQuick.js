function ShowSaveModal(elem) {
	var dataId = $(elem).data("id");
	$.ajax({
		url: "/Laptop/QuickView?id=" + dataId,
		success: function (data) {
			$('#createModal').html(data);
			$("#createModal").modal("show");
		},
		error: function (error) {
			console.log(error);
		}
	});
}