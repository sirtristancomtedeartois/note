(function ($) {
    /*app register*/
    var apps = {};

    $(this).bind("registerApp", function (event, app) {
        if (app.appMeta.type = "window") {
            if (apps[app.appMeta.name] === undefined) {
                apps[app.appMeta.name] = app.main;
            }
        }
    });

    /*app ui cache*/
    var appUICache = {};

    var addToAppUICache = function (app) {
        if (app.appMeta.type === "window") {
            $("#windowAppCache").prepend("<div></div>").prepend(app.html);
            appUICache[app.appMeta.name] = $("#windowAppCache > div:first-child");
            appUICache[app.appMeta.name].css("display", "none");
            appUICache[app.appMeta.name].addClass("windowApp");
        }
    }

    $(this).bind("cacheAppUI", function (event, app) {
        addToAppUICache(app);
    });

    /*open an app*/
    $(this).bind("open", function (event, appMeta, header, para, onOpenned) {
        event.preventDefault();
        if (appMeta.type = "window") {
            var appUIName = appMeta.name;
            if (header !== undefined) {
                appUIName = [appUIName, ".", header].join("");
            }

            if (appUICache[appUIName] === undefined) {
                if (apps[appMeta.name] !== undefiend) {
                    var app = { "appMeta": { "name": appUIName, "type": appMeta.type }, "html": apps[appMeta.name](header, para) };
                }
                addToAppUICache(app);
            }

            appUICache[appUIName].show();
            if (onOpenned !== undefined) {
                $("#windowAppCache").show("slide", {}, 500, onOpenned)
            } else {
                $("#windowAppCache").show("slide", {}, 500);
            }
        }
    });
})(jQuery);
