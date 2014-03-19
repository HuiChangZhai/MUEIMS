(function ($) {
    "use strict";
    $.fn.FileInput = function (options) {
        options = $.extend({}, $.FileInput.defaults, options);

        return $(this).each(function (i) {
            var buttonElement;
            var clearLinkText;
            var clone;
            var container;
            var doc = document;
            var element = $(this);
            var files;
            var fileElement;
            var fileName;
            var i;
            var isLink;
            var isOpera = !!window.opera;
            var isIe = !!window.ActiveXObject;
            var length;
            var namespace = options.namespace;
            var textElement;

            if (!element.attr("id")) {
                element.attr("id", Math.random().toString().replace(".", "-"));
            }

            element.data("FileInput.options", options);

            container = $(doc.createElement(options.containerTagName)).attr({
                id: namespace + "-" + element.attr("id"),
                "class": options.containerClassName
            }).insertAfter(element);

            $(doc.createElement("span")).appendTo(container).append(element);
            $(doc.createElement("input")).attr(options.buttonAttributes).attr("type", "button").appendTo(container);

            textElement = $(doc.createElement(options.textTagName)).attr(options.textAttributes).appendTo(container);

            if (options.textAttributes.text) {
                textElement.text(options.textAttributes.text);
            }

            if (options.addClearLink) {
                $(doc.createElement("a")).attr("href", "#").appendTo(container).hide();
            }

            element.bind("change." + namespace + " mouseover." + namespace + " mouseout." + namespace, function (event) {
                element = $(this);
                container = element.closest("[id]:not(:input)");
                clearLinkText = $("a", container);
                textElement = $(">:nth-child(3)", container);
                buttonElement = $("[type=button]", container);
                fileName = $("[type=file]", container).val();
                files = element[0].files;
                options = element.data("FileInput.options");

                if (event.type === "change" && element.val().length) {
                    clearLinkText.show();
                    buttonElement.addClass(options.buttonActiveClassName);
                    textElement.html("");

                    if (files) {
                        fileName = [];

                        for (i = 0, length = files.length; i < length; ++i) {
                            if (textElement.is("input, textarea")) {
                                fileName.push(files[i].name ? files[i].name : files[i].fileName);
                            } else {
                                $(options.textFileListHtml.replace(/%s/g, files[i].name ? files[i].name : files[i].fileName)).addClass(files[i].type ? files[i].type.replace(/\//g, "-") : "").appendTo(textElement);
                                clearLinkText.text(!i ? options.clearLinkText[0] : options.clearLinkText[1]);
                            }
                        }

                        if (fileName.length) {
                            clearLinkText.text(fileName.length === 1 ? options.clearLinkText[0] : options.clearLinkText[1]);
                            fileName = fileName.toString().replace(/,/g, ", ");
                        }
                    } else {
                        if (fileName.indexOf("\\") > -1) {
                            clearLinkText.text(options.clearLinkText[0]);
                            fileName = fileName.substring(fileName.lastIndexOf("\\") + 1);
                        }
                    }

                    try {
                        textElement.val(fileName);
                        textElement.text(fileName);
                    } catch (e) { }
                } else if (event.type !== "change") {
                    buttonElement.toggleClass(options.buttonHoverClassName);
                }
            });

            $(">:nth-child(3), a", container).bind("click." + namespace + " change." + namespace + " keyup." + namespace + " focus." + namespace, function (event) {
                element = $(this);
                container = element.closest("[id]:not(:input)");
                fileElement = $("[type=file]", container);
                textElement = $(">:nth-child(3)", container);
                buttonElement = $("[type=button]", container);
                clone = fileElement.clone(true);
                isLink = element.is("a");
                options = fileElement.data("FileInput.options");

                if (event.type === "focus" && !isLink && element.val() !== options.textAttributes.value) {
                    setTimeout(function () {
                        textElement.select();
                    }, 1);
                } else if ((isLink && event.type === "click") || (!isLink && !element.val().length)) {
                    $("a", container).hide();
                    buttonElement.removeClass(options.buttonActiveClassName);

                    textElement.text(options.textAttributes.text);
                    textElement.val(options.textAttributes.value);

                    if (isOpera) {
                        clone.attr("type", "text").val("").attr("type", "file");
                    }

                    isOpera || isIe ? clone.replaceAll(fileElement) : fileElement.val("");
                    return isLink ? false : null;
                }
            });
        });
    };

    $.FileInput = {
        defaults: {
            namespace: "FileInput",
            containerTagName: "span",
            containerClassName: "FileInputContainer",
            addClearLink: false,
            clearLinkText: ["Remove File", "Remove Files"],
            buttonHoverClassName: "hover",
            buttonActiveClassName: "active",
            buttonAttributes: {
                "class": "FileInputButton",
                value: "Browse"
            },
            textTagName: "input",
            textAttributes: {
                "class": "FileInputText",
                type: "text"
            },
            textFileListHtml: "<em>%s, <em>"
        }
    }
})(jQuery);