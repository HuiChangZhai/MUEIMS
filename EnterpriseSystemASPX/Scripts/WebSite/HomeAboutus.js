function ClearMessage()
{
    $("#Mname").val("");
    $("#Mtel").val("");
    $("#Memail").val("");
    $("#Mmessage").val("");
    $("#MnameError").html("");
    $("#MtelError").html("");
    $("#MemailError").html("");
    $("#MmessageError").html("");
}

function SendMessage() {
    var name = $("#Mname").val();
    var tel = $("#Mtel").val();
    var email = $("#Memail").val();
    var message = $("#Mmessage").val();
    //验证数据
    if(name.trim()==""||name.trim().toLowerCase()=="undefined")
        $("#MnameError").html("请输入公司名称");
    if (tel.trim() == "" || tel.trim().toLowerCase() == "undefined")
        $("#MtelError").html("请输入联系电话");
    if (message.trim() == "" || message.trim().toLowerCase() == "undefined")
        $("#MmessageError").html("请输入您的留言");
    if (tel.trim() == "" || tel.trim().toLowerCase() == "undefined")
        $("#MemailError").html("请输入邮箱地址");
    else
    {
        var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
        if (!reg.test(email))
            $("#MemailError").html("请输入正确的邮箱地址");
    }
    if ($("#MnameError").html("").trim() == "" && $("#MemailError").html("").trim() == "" && $("#MtelError").html("").trim() == "" && $("#MnameError").html("").trim() == "")
        return;
    var url = "/Home/SendMessage?name=" + name + "&tel=" + tel + "&email=" + email + "&message=" + message;
    $(".success").show();
    window.location.href = url;
}