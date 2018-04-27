/// <reference path="Libs/requirejs/require.js" />
;
//当页面加载完成后展示body,防止加载时布局变乱
window.onload = function () {
    var classes = document.getElementsByTagName('body')[0].classList;
    classes.remove('hidden');
}

;
var app = {
    rootPath: '',
    url: function (uri) {
        if (uri && String(uri).trim().startsWith(app.rootPath)) {
            return uri;
        }
        return app.rootPath + String(uri).trim();
    },
    go: function (uri) {
        window.location.href = app.url(uri);
    },



    //requirejs 脚本配置
    scripts: {
        baseUrl: '/Scripts/',
        paths: {
            jquery: 'libs/jquery-1.11.3.min',
            metadata: 'libs/jquery.metadata',
            css: 'libs/requirejs/css',
            bootstrap: 'libs/bootstrap/js/bootstrap.min',
            jqvalidate: 'libs/validate/jquery.validate-1.10.0',
            layer: 'libs/layer/layer',
            utils: 'public/utils',
            bootstrapHelper: 'public/bootstrapHelper',
            bootstrapTable: 'libs/bootstrap/js/bootstrap-table',
            webuploader: 'libs/webuploader/js/webuploader',
            validate: 'libs/validate/additional-methods',
            contextMenu: 'libs/contextmenu/js/contextMenu',
        },
        shim: {
            metadata: ['jquery'],
            bootstrap: {
                deps: [
                    'jquery',
                   // 'css!libs/font-awesome-3.2.1/css/font-awesome.css',
                    'css!libs/font-awesome-4.7.0/css/font-awesome.css',
                    'css!libs/bootstrap/css/bootstrap.min.css',
                ],
            },
            bootstrapTable: {
                deps: [
                    'bootstrap',
                    'css!libs/bootstrap/css/bootstrap-table.css',
                ]
            },
            contextMenu: {
                deps: [
                       'css!libs/contextMenu/css/contextMenu.css',
                ]
            },
            jqvalidate: {
                deps: [
                    'jquery',
                    'metadata',
                ]
            },
            validate: {
                deps: [
                    'jqvalidate'
                ],
            },
            layer: {
                deps: [
                    'css!libs/layer/theme/default/layer.css',
                    'jquery',
                ]
            },
            webuploader: {
                deps: [
                    'css!libs/webuploader/css/webuploader.css',
                    'jquery'
                ]

            }
        }
    }
};
app.module =
require.config(app.scripts);


