$(".btnDelAuthor").click(function () {
    showModal(event.target);
});

$(".btnEditAuthor").click(function () {
    showModal(event.target);
});

$(".btnCreateAuthor").click(function () {
    showModal(event.target);
});

$(function () {
    $("#myTable").tablesorter({
        sortList: [[0, 1]]
    });
    $("#myTable").removeClass("hidden");
});