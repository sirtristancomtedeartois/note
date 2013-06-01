(function ($) {
    var appMeta = { "name": "editor", "type": "window" }; 
    var editor = "";
    $.event.trigger("cacheAppUI", { "appMeta": appMeta, "html": editor }); // name could be namespaced as "appname.filename(encoded)"
    $.event.trigger("registerApp", {
        "appMeta": appMeta,
        "main": function (header, para) {
            return ""
        }
    }) // open appname, header, para
})(jQuery);