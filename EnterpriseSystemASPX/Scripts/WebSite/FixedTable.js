//FixedTable.js

$(document).ready(function ($) {
    FreezeHeader();
});

function FreezeHeader() {
    var TableView = $("table.Fixed");
    var TableViewHeader = $("table.Fixed>thead");

    if ($("#FloatingTable").length > 0) {
        $("#FloatingTable").remove();
    }

    if (TableView && TableViewHeader) {
        $("body").append("<table id=\"FloatingTable\" style=\"position: fixed; top: -1px; display: none;\" class=\"Table\" cellpadding=\"0\" cellspacing=\"0\"></table>");

        var CellWidth;
        var FloatingTable = $("#FloatingTable")
        var TableViewHeaderHeight = TableViewHeader.height();
        $("#FloatingTable").height(TableViewHeaderHeight);
        $("table.Fixed>thead>tr:first>th").each(function (Index) {
            CellWidth = Math.ceil($(this).outerWidth()) + 1;

            $(this).css({
                "width": CellWidth + "px",
                "min-width": CellWidth + "px",
                "max-width": CellWidth + "px"
            });
        });

        $("table.Fixed>tbody>tr:first>td").each(function (Index) {
            CellWidth = Math.ceil($(this).outerWidth());

            $(this).css({
                "width": CellWidth + "px",
                "min-width": CellWidth + "px",
                "max-width": CellWidth + "px"
            });
        });

        $("table.Fixed>thead>tr:first").clone().appendTo("#FloatingTable");

        $(window).scroll(function () {
            var Window = $(this);
            var TableViewPosition = TableView.offset();

            if (TableViewPosition) {
                if (TableViewPosition.top < Window.scrollTop()) {
                    FloatingTable.css({
                        "left": (TableViewPosition.left - Window.scrollLeft()) + "px",
                        "z-index": "1000",
                        "width": $("table.Fixed").width() + "px"
                    }).show();
                } else {
                    FloatingTable.hide();
                }
            }
        });
    }
}