﻿function ShopCartModal() {
	$.ajax({
		url: "/ShopCart/ShopCartModal",
		success: function (data) {
			$('#shopCart').html(data);
			$("#shopCart").modal("show");
		},
		error: function (error) {
			console.log(error);
		}
	});
}

function ShowDeleteModal(elem) {
	var dataId = $(elem).data("id");
	$.ajax({
		url: "/ShopCart/Delete?id=" + dataId,
		success: function (data) {
			$('#shopCart').html(data);
			$("#shopCart").modal("show");
		},
		error: function (error) {
			console.log(error);
		}
	});
}

function AddToCard() {
	alert("salam");
	var id = $("#ProductId").val();
	var productType = $("#ProductType").val();
	var count = $("#qty").val();
	var obj = {
		ProductId: id,
		ProductType: productType,
		Count: count
	}
	$.ajax({
		url: "/Home/AddToCard",
		method: "POST",
		data: obj,
		success: function (data) {
			alert("sala");
		},
		error: function (err) {
			console.error(err);
		}
	})
}