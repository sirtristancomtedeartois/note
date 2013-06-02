(function ($) {
    /*private lib*/
    var concatHeader = function (appName, appHeader) {
        var appUIName = appName;
        if (appHeader !== undefined) {
            appUIName = [appUIName, ".", appHeader].join("");
        }

        return appUIName;
    }

    /*app registry*/
    var apps = { "window": {} };

    $(this).bind("registerApp", function (event, app) {
        if (app.appMeta.type = "window") {
            if (apps.window[app.appMeta.name] === undefined) {
                apps.window[app.appMeta.name] = app.callBacks;
            }
        }
    });

    /*app ui cache*/
    var windowAppUICache = {};

    var addToWindowAppUICache = function (app) {
        if (app.appMeta.type === "window") {
            $("#windowAppCache").prepend("<div></div>").prepend(app.html);
            windowAppUICache[app.appMeta.name] = $("#windowAppCache > div:first-child");
            windowAppUICache[app.appMeta.name].addClass("windowApp");
            windowAppUICache[app.appMeta.name].css("height", $("#windowAppCache").height() - parseInt(windowAppUICache[app.appMeta.name].css("top")) * 2 + "px");
            windowAppUICache[app.appMeta.name].click(function (event) {
                return false;
            })
        }
    }

    $(this).bind("cacheWindowAppUI", function (event, app) {
        addToWindowAppUICache(app);
    });

    /*open an app*/
    var opennedWindowApp = new Array();

    $(this).bind("open", function (event, appMeta, header, para, onOpen) {
        event.preventDefault();
        if (appMeta.type = "window") {
            var appUIName = concatHeader(appMeta.name, header);

            if (windowAppUICache[appUIName] === undefined) {
                if (apps.window[appMeta.name] !== undefiend) {
                    var app = { "appMeta": { "name": appUIName, "type": appMeta.type }, "html": apps.window[appMeta.name].main(header, para) };
                }
                addToWindowAppUICache(app);
            }

            windowAppUICache[appUIName].show();
            if (onOpen !== undefined) {
                $("#windowAppCache").show("slide", {}, 150, onOpen)
            } else {
                $("#windowAppCache").show("slide", {}, 150);
            }

            opennedWindowApp.push({ "name": appMeta.name, "header": header })
        }
    });

    /*close window app panel*/
    $("#windowAppCache").click(function (event) {
        $(this).hide("drop", {}, 150, function () {
            for (var key in opennedWindowApp) {
                var app = opennedWindowApp[key];
                var appUIName = concatHeader(app.name, app.header);
                windowAppUICache[appUIName].hide();
                apps.window[app.name].onClose(app.header);
                //            if (appUICache.hasOwnProperty(key)) {
                //                alert(key + " -> " + p[key]);
                //            }
            }

            opennedWindowApp = new Array(); //reset this array, since we closed all
        }); 
    })
})(jQuery);
