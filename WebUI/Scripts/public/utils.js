;
define(['jquery', 'validate', 'layer'], function ($) {
    //扩展方法
    $.fn.extend({
        //把Form表单转换为对象
        serializeForm: function () {
            var el = this.selector;
            var arr = $(el).serializeArray();
            var obj = {};
            $(arr).each(function (k, v) {
                obj[v.name] = v.value;
            });
            return obj;
        },
        pushRange: function (array) {
            var $this = this;
            if (array && array.length > 0) {
                for (var i = 0; i < array.length; i++) {
                    $this.push(array[i]);
                }
                return $this;
            } else {
                return $this;
            }

        },
        isValid: function () {
            var el = this.selector;
            var validator = $(el).validate();
            var f = validator.form();
            return f;
        }
    });
    var utils = {
        //数据字典过滤器
        dictionaryFilter: function (val, type) {
            var names = "";
            var name;
            $.utils.send({
                url: '/Dictionary/Get',
                data: {
                    type: type,
                },
                async: false,
                success: function (data) {
                    names = data;
                }
            });
            $(names).each(function (k, v) {
                if (v.data_value == val) {
                    name = v.data_text;
                }
            });
            return name;
        },
        //把json格式的时间转换为字符串
        toTimeString: function (val) {
            if (val && String(val).trim().length > 0) {
                val = String(val).trim();
                var obj = eval('new ' + (val.replace(/\//g, '')));
                var hours = obj.getHours();
                if (hours < 10) {
                    hours = "0" + hours;
                }
                var minutes = obj.getMinutes();
                if (minutes < 10) {
                    minutes = "0" + minutes;
                }
                var seconds = obj.getSeconds();
                if (seconds < 10) {
                    seconds = "0" + seconds;
                }
                return obj.toLocaleDateString() + " " + hours + ":" + minutes + ":" + seconds;// obj.toTimeString();
            }
            return "";
        },
        /*设置cookie*/
        setCookie: function (name, value, days) {
            if (days == null || days == '') {
                days = 300;
            }
            var exp = new Date();
            exp.setTime(exp.getTime() + days * 24 * 60 * 60 * 1000);
            document.cookie = name + "=" + escape(value) + "; path=/;expires=" + exp.toGMTString();
        },

        /*获取cookie*/
        getCookie: function (name) {
            var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            if (arr = document.cookie.match(reg))
                return unescape(arr[2]);
            else
                return null;
        },
        //获取地址栏的参数的方法,参数name为参数名称
        queryString: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) {
                return unescape(r[2]);
            }
            return null;
        },
        ajaxing: false,
        loading: '',
        send: function (opt) {
            var options = {
                type: 'post',
                dataType: 'json',

                contentType: 'application/x-www-form-urlencoded',
                beforeSend: function (xhr) {
                    utils.ajaxing = true;
                    utils.loading = layer.load(1, {
                        shade: [0.2, '#fff'] //0.1透明度的白色背景
                    });
                    if (opt.beforeSend) {
                        opt.beforeSend(xhr);
                    }
                },
                error: function (response) {
                    utils.ajaxing = false;
                    layer.close(utils.loading);
                    if (opt.error) {
                        opt.error(response);
                    } else {
                        alert('ajax请求错误:');
                        console.error(response);
                    }
                },
                complete: function (xhr, ts) {
                    utils.ajaxing = false;
                    layer.close(utils.loading);
                    if (opt.complete) {
                        opt.complete(xhr, ts);
                    }
                }
            };
            $.extend(options, opt);
            options.url = app.url(opt.url);
            if (!utils.ajaxing) {
                $.ajax(options);
            } else {
                layer.msg('正在处理,请稍后...', { icon: 4 });
                return false;
            }
        },
        //打开一个iframe窗口,基于layer
        open: function (opt) {
            var height = $(window).height() * 2 / 3;
            var width = $(window).width() * 1 / 2;
            var options = {
                type: 2,    //默认是iframe, 1是body
                title: '窗口',
                area: [width + 'px', height + 'px'],
                fixed: false, //不固定
                maxmin: true, //最大化最小化
                content: '',//可以是地址
            };
            $.extend(options, opt);
            layer.open(options);
            //console.log(parent);
            //var titleCss={
            //    backgroundColor:parent.$('header.layout-header').css('backgroundColor'),
            //    color: parent.$('header.layout-header .header-logo').css('color'),
            //};
            //$('.layui-layer-title').css(titleCss);
        }
    };
    $.extend({ utils: utils });
    return utils;
});