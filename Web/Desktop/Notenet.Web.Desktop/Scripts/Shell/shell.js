(function ($) {
    /*app register*/
    var apps = [];

    $(this).bind("registerApp", function (event, app) {
        if (app.appMeta.type = "window") {
            if (apps[app.appMeta.name] === undefined) {
                apps[app.appMeta.name] = app;
            }
        }
    });

    /*app ui cache*/
    var appUICache = [];

    var addToAppUICache = function (app) {
        $("windowAppCache").prepend("<div></div>").prepend(app.html);
        appUICache[app.appMeta.name] = $("windowAppCache:first-child");
        appUICache[app.appMeta.name].css("display", "none");
        appUICache[app.appMeta.name].addClass("windowApp")
    }

    $(this).bind("cacheAppUI", function (event, app) {
        if (app.appMeta.type === "window") {
            addToAppUICache(app);
        }
    });

    /*open an app*/
    $(this).bind("open", function (event, appMeta, header, para) {
        if (appMeta.type = "window") {
            var appUIName = appMeta.name;
            if (header !== undefined) {
                appUIName = appUIName + "." + header;
            }

            if (appUICache[appUIName] === undefined) {
                if (apps[appMeta.name] !== undefiend) {
                    var app = { "appMeta": appMeta, "html": apps[appMeta.name].main(header, para) };
                    appMeta.name = appUIName;
                }
                addToAppUICache(app);
            }

            appUICache[appUIName].show();
            appUICache["windowAppCache"].show("slide", {}, 500, callback)
        }
    });
})(jQuery);
