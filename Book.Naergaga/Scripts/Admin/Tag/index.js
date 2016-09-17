$(".btnDelTag").click(function () {
    $.get($(event.target).attr("spot"), function (d) {
        $(".body-content").prepend(d);
        $("#deleteModal").modal("show");
    });
});

$(".btnEditTag").click(function () {
    $.get($(event.target).attr("spot"), function (d) {
        $(".body-content").prepend(d);
        $("#deleteModal").modal("show");
    });
});
$(function () {
    $("#myTable").tablesorter({
        sortList: [[0, 1]]
    });
    $("#myTable").removeClass("hidden");
});