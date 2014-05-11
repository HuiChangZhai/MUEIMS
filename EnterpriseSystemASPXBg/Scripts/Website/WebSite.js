//WebSite.js

function validateForm(Form) {
    Form = $(Form);

    var MissingFieldList = "";
    var StartDate = null;
    var EndDate = null;

    $.each($("*[encreq='true']", Form), function () {
        var Element = $(this);

        if (Element.val() == "") {
            Element.addClass("FieldError");

            if (Element.attr("alias") && Element.attr("alias") != "") {
                MissingFieldList += Element.attr("alias") + "\n";
            } else {
                MissingFieldList += Element.attr("title") + "\n";
            }
        } else {
            Element.removeClass("FieldError");
        }
    });

    if (MissingFieldList != '') {
        alert("The Following Fields are Required: \n\n" + MissingFieldList);
        return false;
    } else {
        return true;
    }
}

function checkRequiredFields(Form) {
    setTimeout(function () {
        if (validateForm(Form)) {
            Form.submit();
            return true;
        }

        return false;
    }, 100);
}

function checkFieldWithPatern(inputObj, pattern) {
    if (inputOb) {
        var val = $(inputObj).val();
        var regexp = new RegExp(pattern);
        return regexp.test(val);
    }
    else {
        return false;
    }
}