var HTMLEncoding = (function ($) {
    return {
        Encoding: function (HTML) {
            HTML = HTML || "";
            return $("<div></div>").text(HTML).html();
        },
        Decoding: function (CodingCode) {
            CodingCode = CodingCode || "";
            return $("<div></div>").html(CodingCode).text();
        },
        HTML2Txt: function (HTML) {
            HTML = HTML || "";
            return $("<div></div>").html(HTML).text()
        },
        Coding2Txt: function (CodingCode) {
            CodingCode = CodingCode || "";
            return this.HTML2Txt(this.Decoding(CodingCode));
        }
    };
})(jQuery);