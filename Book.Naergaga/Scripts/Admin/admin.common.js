function showModal(item) {
	$.get($(item).attr("spot"), function (d) {
		$(".body-content").prepend(d);
		$("#deleteModal").modal("show");
	});
}