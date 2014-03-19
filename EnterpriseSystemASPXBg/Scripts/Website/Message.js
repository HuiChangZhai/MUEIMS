function MessageDetail(index) {

}

function DeleteDetail(index) {
    if (confirm("你确定要删除吗?")) {
        window.location.href = "/AdminHome/MessageDelete?id=" + index;
    }
}

function changeBgcolor(index) {
    //var count = index % 2;
    //if (count == 0) {
        $("#tr" + index).css("background-color", "#ccf");
    //}
    //if (count == 1) {
    //    $("#tr" + index).css("background-color", "");
    //}
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

function addCases() {
    var select = $("#caseslist").val();
    if (select == "0") {
        alert("请选择企业用户");
        return false;
    }
    var type=confirm("你确定要添加到成功案例吗?");
    return type;
}