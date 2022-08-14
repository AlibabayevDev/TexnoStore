function ShopCartModal() {
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