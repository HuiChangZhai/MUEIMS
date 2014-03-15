function MessageDetail(index)
{

}

function DeleteDetail(index) {
    if (confirm("你确定要删除吗?"))
    {
        window.location.href = "/AdminHome/MessageDelete?id=" + index;
    }
}

function changeBgcolor(index)
{
    var count = index % 2;
    if (count == 0)
    {
        $("#tr" + index).css("background-color", "#ccf");
    }
    if (count == 1) {
        $("#tr" + index).css("background-color", "");
    }
}

function clearBgcolor(index)
{
    $("#tr" + index).css("background-color", "");
}