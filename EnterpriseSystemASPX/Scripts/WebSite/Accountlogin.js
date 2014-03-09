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
    else
        $("#emailError").val("");
    var url = "/Account/Login?email=" + email;
    $.ajax({
        type: "get",
        url: url,
        dataType: "html",
        success: function (data) {
            $("#emailError").html(data);
        }
    });
}

function Logout() {
    var url = "/Account/Logout";
    window.location.href = url;
}

function AccountLogin()
{
    var emailerror = $("#emailError").html();
    var pwderror = $("#pwdError").html();
    var loginerror = $("#loginError").html();
    if (emailerror.trim() == "" && pwderror.trim() == "" && loginerror.trim() == "") {
        var email = $("#useremail").val();
        var remember = $('input[name=rememberme]').is(':checked');
        var pwd = $("#userpwd").val();
        var url = "/Account/Login?email=" + email + "&pwd=" + pwd + "&remember=" + remember;
        window.location.href = url;
        $("#emailError").html("");
        $("#pwdError").html("");
        $("#loginError").html("");
        //AjaxMethod(url,)
    }
}