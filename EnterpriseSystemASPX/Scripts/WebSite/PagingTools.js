/*
@TotalPage
@ShowPage
@CurrentPage
@CallBackFun
@TagName
*/
  
String.prototype.supplant = (function () {
    return function (o) {
        return this.replace(/\{([^{}]+)\}/g, function (source, key) {
            return (typeof o[key] === "string" || typeof o[key] === "number") ? o[key] : source;
        });
    };
})();


function PagingTools(options) {
    var _options = {
        TotalPage:0,
        ShowPage:10,
        CurrentPage:0,
        CallBackFun: function (page) { },
        TagName: "div",
        Separat: " | ",
        ItemClass: "-paging-itens",
        CurrentItemClass: "-paging-current",
        NoFocusItem: "-paging-no-focus-item"
    };

    $.extend(_options, options);

    var HTML = $("<div></div>");
    //    .css({
    //    "-webkit-touch-callout" : "none;",
    //    "-webkit-user-select" : "none;",
    //    "-khtml-user-select" : "none;",
    //    "-moz-user-select" : "-moz-none;",
    //    "-ms-user-select" : "none;",
    //    "user-select" : "none;"
    //});

    this.reander = function (parentElement, opts) {
        $.extend(_options, opts);

        HTML.empty();
        
        var _currentPage = parseFloat(_options.CurrentPage);
        var _totalPages = parseFloat(_options.TotalPage);
        var _item = "<" + _options.TagName + " style=\"display:inline-block;\">" + "{page}" + "</" + _options.TagName + ">";
        var _Separat = _options.Separat.replace(/\s/g,"&nbsp;");
        var _maxPage = Math.min(_options.CurrentPage + _options.ShowPage, _options.TotalPage);
        var _callBackFun = _options.CallBackFun;

        function AppendToHTML(item) {
            if (HTML.html() !== "") {
                HTML.append($(_item.supplant({ page: _Separat })).addClass(_options.NoFocusItem));
            }

            if (typeof item === "string") {
                HTML.append($("<" + _options.TagName + " style=\"display:inline-block;\">" + item + "</" + _options.TagName + ">"));
            }
            else {
                HTML.append(item);
            }
        }
        if (_currentPage > 1) {
            // 上一页可用
            AppendToHTML($(_item.supplant({ page: "&laquo;" })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(1)));
            AppendToHTML($(_item.supplant({ page: "&lsaquo;" })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(_currentPage - 1)));
        }
        else {
            AppendToHTML($(_item.supplant({ page: "&laquo;" })).addClass(_options.NoFocusItem));
            AppendToHTML($(_item.supplant({ page: "&lsaquo;" })).addClass(_options.NoFocusItem));
        }


        var prevPageLimit = (_options.ShowPage % 2 == 0 ? _options.ShowPage / 2 - 1 : (_options.ShowPage - 1) / 2);
        var nextPageLimit = _options.ShowPage - 1 - prevPageLimit;
        var prevPage = _currentPage > prevPageLimit ? prevPageLimit : _currentPage - 1;
        var nextPage = _totalPages - _currentPage > nextPageLimit ? nextPageLimit : _totalPages - _currentPage;
        if (prevPage < prevPageLimit && nextPage == nextPageLimit) {
            nextPage = _totalPages - _currentPage > (_options.ShowPage - 1) - prevPage ? (_options.ShowPage - 1) - prevPage : _totalPages - _currentPage;
        }
        else if (prevPage == prevPageLimit && nextPage < nextPageLimit) {
            prevPage = _currentPage > (_options.ShowPage - 1) - nextPage ? (_options.ShowPage - 1) - nextPage : _currentPage - 1;
        }

        while (prevPage > 0) {
            //HTML += "_" + (_currentPage - prevPage);
            AppendToHTML($(_item.supplant({ page: _currentPage - prevPage })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(_currentPage - prevPage)));
            prevPage--;
        }

        AppendToHTML($(_item.supplant({ page: _currentPage })).addClass(_options.CurrentItemClass));

        var tmpPage = nextPage + 1;
        while (nextPage > 0) {
            var page = _currentPage + (tmpPage - nextPage)

            //HTML += "_" + page;
            AppendToHTML($(_item.supplant({ page: page })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(page)));

            nextPage--;
        }



        if (_currentPage < _maxPage) {
            // 下一页可用
            AppendToHTML($(_item.supplant({ page: "&rsaquo;" })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(_currentPage + 1)));
            AppendToHTML($(_item.supplant({ page: "&raquo;" })).addClass(_options.ItemClass).click((function (page) {
                var _page = page;
                return function () {
                    _callBackFun(_page);
                };
            })(_totalPages)));
        }
        else {
            AppendToHTML($(_item.supplant({ page: "&rsaquo;" })).addClass(_options.NoFocusItem));
            AppendToHTML($(_item.supplant({ page: "&raquo;" })).addClass(_options.NoFocusItem));
        }

        //AppendToHTML()
        HTML.append($(_item.supplant({ page: "共" + _totalPages + "页" })).css("padding-left","20px").addClass(_options.NoFocusItem));

        HTML.appendTo(parentElement);
    }
}