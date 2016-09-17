$(".btnDelCategory").click(function () {
    showModal(event.target);
});

$(".btnEditCategory").click(function () {
    showModal(event.target);
});

$(".btnCreateCategory").click(function () {
    showModal(event.target);
});

$(function () {
    $("#myTable").tablesorter({
        sortList: [[0, 1]]
    });
    $("#myTable").removeClass("hidden");
});