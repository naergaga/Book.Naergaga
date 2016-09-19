$(".btnDelTag").click(function () {
    showModal(event.target);
});

$(".btnEditTag").click(function () {
    showModal(event.target);
});

$(".btnCreateTag").click(function () {
    showModal(event.target);
});

$(function () {
    $("#myTable").tablesorter({
        sortList: [[0, 1]]
    });
    $("#myTable").removeClass("hidden");
});