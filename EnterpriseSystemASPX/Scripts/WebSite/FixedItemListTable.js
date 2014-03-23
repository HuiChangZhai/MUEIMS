$(document).ready(function () {
    $(".ItemListTable").children("tbody").children("tr").each(function (index, item) {
            $(item).mouseover(function () {
                $(this).addClass("hover");
            }).mouseout(function () {
                $(this).removeClass("hover");
            });
    });
});


function DeleteDetail(index) {
    if (confirm("你确定要删除吗?")) {
        window.location.href = "/AdminHome/MessageDelete?id=" + index;
    }
}

function changeBgcolor(index) {
    $("#tr" + index).css("background-color", "#ccf");
}

function clearBgcolor(index) {
    $("#tr" + index).css("background-color", "");
}

function DeleteEDetail(index) {
    if (confirm("你确定要删除吗?")) {
        window.location.href = "/AdminHome/DeleteEnterprise?id=" + index;
    }
}

function DeleteCDetail() {
    if (confirm("你确定要删除吗?")) {
        window.location.href = "/AdminHome/DeleteCases?id=" + index;
    }
}