(function ($) {
    var editor = "";
    $.event.trigger("cacheWindowAppUI", { "appMeta": { "name": "editor", "type": "window" }, "html": editor }); // name could be namespaced as "appname.filename(encoded)"
    $.event.trigger("registerApp", {
        "appMeta": { "name": "editor", "type": "window" },
        "callBacks": {
            "main": function (header, para) {
                return ""
            },
            "onClose": function (header) {

            }
        }
    }) // open appMeta, header, para
})(jQuery);
