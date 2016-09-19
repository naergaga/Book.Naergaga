function showModal(item) {
	$.get($(item).attr("spot"), function (d) {
		$("#modal").html(d);
		$("#deleteModal").modal("show");
	});
}