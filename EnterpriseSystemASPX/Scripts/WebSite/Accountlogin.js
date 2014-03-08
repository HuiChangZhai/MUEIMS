function AjaxMethod(url,divid,postmethod)
{
    $.ajax({
        type: postmethod,
        url: url,
        dataType: "html",
        success: function (data) {
            $("#" + divid).html(data);
        }
    });
}

function CheckExistEmail()
{
    var email = $("#useremail").val();
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
    if (!reg.test(email))
    {
        $("#emailError").val("请输入正确的邮箱地址");
        return;
    }
    var url = "/Account/Login?email=" + email;
    AjaxMethod(url, "emailError","get");
}

function AccountLogin()
{
    var email = $("#useremail").val();
    var pwd = $("#userpwd").val();
    var url = "/Account/Login?email=" + email + "&pwd=" + pwd;
    window.location.href = url;
    //AjaxMethod(url,)
}