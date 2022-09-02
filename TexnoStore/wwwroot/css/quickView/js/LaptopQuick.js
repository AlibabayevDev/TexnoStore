function ShowSaveModal(elem) {
	var dataId = $(elem).data("id");
	var dataType = $(elem).data("type");
	$.ajax({
		url: "/Home/QuickView?id=" + dataId + "&type=" + dataType,
		success: function (data) {
			$('#createModal').html(data);
			$("#createModal").modal("show");
		},
		error: function (error) {
			console.log(error);
		}
	});
}