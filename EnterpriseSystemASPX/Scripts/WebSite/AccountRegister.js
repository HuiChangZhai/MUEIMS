// Accountlogin.js

$(window).load(function () {
    $('#LoginForm').forms({
        ownerEmail: '#',
        showFu: function (data) {
            $("#LoginForm-box").slideUp();
            $("#message-box").html("请到注册邮箱中确认注册用户！").css({
                "height":"200px"
            }).slideDown();
        },
        fieldData: {
            enterpriseName: "enterpriseName",
            enterpriseEmail: "enterpriseEmail",
            enterpriseAddress: "enterpriseAddress",
            enterpriseTel: "enterpriseTel",
            password: "password"
        },
        rx:{
            ".enterpriseName": { rx: /^([\w]|[\u4E00-\u9FA5]){2,20}$/, target: 'input' },
            ".enterpriseEmail": { rx: /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i, target: 'input' }
        },
        mailHandlerURL: "/Account/Register"
    });
})

$(function () {
    $("#confirmPassword").blur(function (e) {
        e.cancelable = true;
        CheckConfirmPassword(e);
    });

    $("#enterpriseEmail").blur(function (e) {
        var pattern = /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i;
        if (pattern.test($("#enterpriseEmail").val())) {
            $.ajax({
                type: "POST",
                url: "/Account/CheckEmailIsAvailable",
                data: {
                    email: $("#enterpriseEmail").val()
                },
                success: function (data) {
                    if (data == "No") {
                        $($("#enterpriseEmail").parent().children("span.error")[0]).text("*该邮箱已被注册.").slideDown();
                    }
                }
            });
        }
    }).focus(function () {
        $($("#enterpriseEmail").parent().children("span.error")[0]).slideUp(undefined, function () { $(this).text("*邮箱格式不正确.") });
    });
});

function CheckConfirmPassword(Event) {
    Event = Event || window.event;
    if ($("#confirmPassword").val() != "") {
        if ($("#confirmPassword").val() == $("#password").val()) {
            $("#confirmPassword").parent().children(".error").first().slideUp();
        } else {
            $("#confirmPassword").parent().children(".error").first().slideDown();
            PreventDefault(Event);
        }
    }
}

function CheckEmail(Event) {
    Event = Event || window.event;
    if ($("#enterpriseEmail").val() != null) {

    }
}

function PreventDefault(Event) {
    Event = Event || window.event;

    if (Event.preventDefault) {
        Event.preventDefault();
    } else {
        Event.returnValue = false;
    }
}