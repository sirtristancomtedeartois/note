(function ($) {
    var editor = "";
    $.event.trigger("cacheAppUI", { "appMeta": { "name": "editor", "type": "window" }, "html": editor }); // name could be namespaced as "appname.filename(encoded)"
    $.event.trigger("registerApp", {
        "appMeta": { "name": "editor", "type": "window" },
        "main": function (header, para) {
            return ""
        }
    }) // open appMeta, header, para
})(jQuery);
