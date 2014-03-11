function SaveChangepwd() {
    var newpwd = $("#newpwd").val();
    var oldpwd = $("#comfirmpwd").val();
    if (newpwd.trim() == "")
        $("#NewpwdError").html("请输入新密码");
    else
        $("#NewpwdError").html("");
    if (oldpwd.trim() == "")
        $("#ComfirmError").html("请输入确认密码");
    else if (oldpwd.trim() != newpwd.trim())
        $("#ComfirmError").html("密码不一致");
    else
        $("#ComfirmError").html("");
    if ($("#NewpwdError").html() == "" && $("#ComfirmError").html() == "")
        $("#formChangepwd").submit();
}