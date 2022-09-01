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
function AddToCardQuick(elem) {
	alert("test");
	var id = $(elem).data("id");
	var count = 1;
	var obj = {
		ProductId: id,
		Count: count
	}
	$.ajax({
		url: "/Home/AddToCard",
		method: "POST",
		data: obj,
		success: function (data) {
		},
		error: function (err) {
			console.error(err);
		}
	})
}