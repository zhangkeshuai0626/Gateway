
require(['jquery', 'css!Admin/css/sccl.css'], function () {//'css!libs/font-awesome-3.2.1/css/font-awesome.css'
    require(['utils'], function () {
        /*左侧菜单点击*/
        $(".side-menu").on('click', 'li a', function (e) {
            var animationSpeed = 300;
            var $this = $(this);
            var checkElement = $this.next();
            if (checkElement.is('.menu-item-child') && checkElement.is(':visible')) {
                checkElement.slideUp(animationSpeed, function () {
                    checkElement.removeClass('menu-open');
                });
                checkElement.parent("li").removeClass("active");
            }
                //如果菜单是不可见的
            else if ((checkElement.is('.menu-item-child')) && (!checkElement.is(':visible'))) {
                //获取上级菜单
                var parent = $this.parents('ul').first();
                //从父级开始找所有打开的菜单并关闭
                var ul = parent.find('ul:visible').slideUp(animationSpeed);
                //在父级中移出menu-open标记
                ul.removeClass('menu-open');
                //获取父级li
                var parenli = $this.parent("li");
                //打开菜单时添加menu-open标记
                checkElement.slideDown(animationSpeed, function () {
                    //添加样式active到父级li
                    checkElement.addClass('menu-open');
                    parent.find('li.active').removeClass('active');
                    parenli.addClass('active');
                });
            }
            //防止有链接跳转
            e.preventDefault();
            addIframe($this);
        });
        /*添加iframe*/
        function addIframe(cur) {
            var $this = cur;
            var h = $this.attr("href") || '';
            var m = $this.data("index") || 0,
                label = $this.find("span").text(),
                isHas = false;

            if (!h || h == 'null' || $.trim(h).length == 0) {
                return false;
            }

            var fullWidth = $(window).width();
            if (fullWidth >= 750) {
                $(".layout-side").show();
            } else {
                $(".layout-side").hide();
            }

            $(".content-tab").each(function () {
                if ($(this).data("id") == h) {
                    if (!$(this).hasClass("active")) {
                        $(this).addClass("active").siblings(".content-tab").removeClass("active");
                        addTab(this);
                    }
                    isHas = true;
                }
            });
            if (isHas) {
                $(".body-iframe").each(function () {
                    if ($(this).data("id") == h) {
                        $(this).show().siblings(".body-iframe").hide();
                    }
                });
            }
            if (!isHas) {
                var tab = "<a href='javascript:;' class='content-tab active' data-id='" + h + "'>" + label + " <i class='icon-font'>&#xe617;</i></a>";
                $(".content-tab").removeClass("active");
                $(".tab-nav-content").append(tab);
                var iframe = "<iframe class='body-iframe' name='iframe" + m + "' width='100%' height='100%' scrolling='auto' src='" + h + "' frameborder='0' data-id='" + h + "' seamless></iframe>";
                $(".layout-main-body").find("iframe.body-iframe").hide().parents(".layout-main-body").append(iframe);
                addTab($(".content-tab.active"));
            }
            return false;
        }
        /*添加tab*/
        function addTab(cur) {
            var prev_all = tabWidth($(cur).prevAll());
            var nexall = tabWidth($(cur).nextAll());
            var other_width = tabWidth($(".layout-main-tab").children().not(".tab-nav"));
            var navWidth = $(".layout-main-tab").outerWidth(true) - other_width;//可视宽度
            var hidewidth = 0;
            if ($(".tab-nav-content").width() < navWidth) {
                hidewidth = 0
            } else {
                if (nexall <= (navWidth - $(cur).outerWidth(true) - $(cur).next().outerWidth(true))) {
                    if ((navWidth - $(cur).next().outerWidth(true)) > nexall) {
                        hidewidth = prev_all;
                        var m = cur;
                        while ((hidewidth - $(m).outerWidth()) > ($(".tab-nav-content").outerWidth() - navWidth)) {
                            hidewidth -= $(m).prev().outerWidth();
                            m = $(m).prev()
                        }
                    }
                } else {
                    if (prev_all > (navWidth - $(cur).outerWidth(true) - $(cur).prev().outerWidth(true))) {
                        hidewidth = prev_all - $(cur).prev().outerWidth(true)
                    }
                }
            }
            $(".tab-nav-content").animate({
                marginLeft: 0 - hidewidth + "px"
            },
            "fast")
        }

        /*获取宽度*/
        function tabWidth(tabarr) {
            var allwidth = 0;
            $(tabarr).each(function () {
                allwidth += $(this).outerWidth(true)
            });
            return allwidth;
        }

        /*左按钮事件*/
        $(".btn-left").on("click", leftBtnFun);
        /*右按钮事件*/
        $(".btn-right").on("click", rightBtnFun);
        /*选项卡切换事件*/
        $(".tab-nav-content").on("click", ".content-tab", navChange);
        /*选项卡关闭事件*/
        $(".tab-nav-content").on("click", ".content-tab i", closePage);
        /*选项卡双击关闭事件*/
        $(".tab-nav-content").on("dblclick", ".content-tab", closePage);


        /*左按钮方法*/
        function leftBtnFun() {
            var ml = Math.abs(parseInt($(".tab-nav-content").css("margin-left")));
            var other_width = tabWidth($(".layout-main-tab").children().not(".tab-nav"));
            var navWidth = $(".layout-main-tab").outerWidth(true) - other_width;//可视宽度
            var hidewidth = 0;
            if ($(".tab-nav-content").width() < navWidth) {
                return false
            } else {
                var tabIndex = $(".content-tab:first");
                var n = 0;
                while ((n + $(tabIndex).outerWidth(true)) <= ml) {
                    n += $(tabIndex).outerWidth(true);
                    tabIndex = $(tabIndex).next();
                }
                n = 0;
                if (tabWidth($(tabIndex).prevAll()) > navWidth) {
                    while ((n + $(tabIndex).outerWidth(true)) < (navWidth) && tabIndex.length > 0) {
                        n += $(tabIndex).outerWidth(true);
                        tabIndex = $(tabIndex).prev();
                    }
                    hidewidth = tabWidth($(tabIndex).prevAll());
                }
            }
            $(".tab-nav-content").animate({
                marginLeft: 0 - hidewidth + "px"
            },
            "fast");
        }

        /*右按钮方法*/
        function rightBtnFun() {
            var ml = Math.abs(parseInt($(".tab-nav-content").css("margin-left")));
            var other_width = tabWidth($(".layout-main-tab").children().not(".tab-nav"));
            var navWidth = $(".layout-main-tab").outerWidth(true) - other_width;//可视宽度
            var hidewidth = 0;
            if ($(".tab-nav-content").width() < navWidth) {
                return false
            } else {
                var tabIndex = $(".content-tab:first");
                var n = 0;
                while ((n + $(tabIndex).outerWidth(true)) <= ml) {
                    n += $(tabIndex).outerWidth(true);
                    tabIndex = $(tabIndex).next();
                }
                n = 0;
                while ((n + $(tabIndex).outerWidth(true)) < (navWidth) && tabIndex.length > 0) {
                    n += $(tabIndex).outerWidth(true);
                    tabIndex = $(tabIndex).next()
                }
                hidewidth = tabWidth($(tabIndex).prevAll());
                if (hidewidth > 0) {
                    $(".tab-nav-content").animate({
                        marginLeft: 0 - hidewidth + "px"
                    },
                    "fast");
                }
            }
        }

        /*选项卡切换方法*/
        function navChange() {
            if (!$(this).hasClass("active")) {
                var k = $(this).data("id");
                $(".body-iframe").each(function () {
                    if ($(this).data("id") == k) {
                        $(this).show().siblings(".body-iframe").hide();
                        return false
                    }
                });
                $(this).addClass("active").siblings(".content-tab").removeClass("active");
                addTab(this);
            }
        }

        /*选项卡关闭方法*/
        function closePage() {
            var url = $(this).parents(".content-tab").data("id");
            var cur_width = $(this).parents(".content-tab").width();
            if ($(this).parents(".content-tab").hasClass("active")) {
                if ($(this).parents(".content-tab").next(".content-tab").size()) {
                    var nexurl = $(this).parents(".content-tab").next(".content-tab:eq(0)").data("id");
                    $(this).parents(".content-tab").next(".content-tab:eq(0)").addClass("active");
                    $(".body-iframe").each(function () {
                        if ($(this).data("id") == nexurl) {
                            $(this).show().siblings(".body-iframe").hide();
                            return false
                        }
                    });
                    var n = parseInt($(".tab-nav-content").css("margin-left"));
                    if (n < 0) {
                        $(".tab-nav-content").animate({
                            marginLeft: (n + cur_width) + "px"
                        },
                        "fast")
                    }
                    $(this).parents(".content-tab").remove();
                    $(".body-iframe").each(function () {
                        if ($(this).data("id") == url) {
                            $(this).remove();
                            return false
                        }
                    })
                }
                if ($(this).parents(".content-tab").prev(".content-tab").size()) {
                    var prev_url = $(this).parents(".content-tab").prev(".content-tab:last").data("id");
                    $(this).parents(".content-tab").prev(".content-tab:last").addClass("active");
                    $(".body-iframe").each(function () {
                        if ($(this).data("id") == prev_url) {
                            $(this).show().siblings(".body-iframe").hide();
                            return false
                        }
                    });
                    $(this).parents(".content-tab").remove();
                    $(".body-iframe").each(function () {
                        if ($(this).data("id") == url) {
                            $(this).remove();
                            return false
                        }
                    })
                }
            } else {
                $(this).parents(".content-tab").remove();
                $(".body-iframe").each(function () {
                    if ($(this).data("id") == url) {
                        $(this).remove();
                        return false
                    }
                });
                addTab($(".content-tab.active"))
            }
            return false
        }


        /*循环菜单*/
        var initMenu = function (menu, parent) {
            for (var i = 0; i < menu.length; i++) {
                var item = menu[i];
                try {
                    if (item.isHeader == "1") {
                        str = "<li class='menu-header'>" + item.name + "</li>";
                        $(parent).append(str);
                        if (item.children != "") {
                            initMenu(item.children, parent);
                        }
                    } else {
                        var icon = item.icon || "&#xe610";
                            var arg = "?AppId="+ item.ApplicationId;
                            var uri='';
                            if(item.Url) {
                              uri = app.url(item.Url+arg);
                            }

                        if (item.children == "") {
                            str = "<li><a href='" + uri + "'><i class='icon-font'>" +icon + "</i><span>" +item.name + "</span></a></li>";
                            $(parent).append(str);
                        } else {
                            str = "<li><a href='" +uri + "'><i class='icon-font '>" + icon + "</i><span>" +item.name + "</span><i class='icon-font icon-right'>&#xe60b;</i></a>";
                            str += "<ul class='menu-item-child' id='menu-child-" + item.id + "'></ul></li>";
                            $(parent).append(str);
                            var childParent = $("#menu-child-" + item.id);
                            initMenu(item.children, childParent);
                        }
                    }
                } catch (e) { }
            }
        }
        /*头部下拉框移入移出*/
        $(document).on("mouseenter", ".header-bar-nav", function () {
            $(this).addClass("open");
        });
        $(document).on("mouseleave", ".header-bar-nav", function () {
            $(this).removeClass("open");
        });

        /*左侧菜单展开和关闭按钮事件*/
        $(document).on("click", ".layout-side-arrow", function () {
            if ($(".layout-side").hasClass("close")) {
                $(".layout-side").removeClass("close");
                $(".layout-main").removeClass("full-page");
                $(".layout-footer").removeClass("full-page");
                $(this).removeClass("close");
                $(".layout-side-arrow-icon").removeClass("close");
            } else {
                $(".layout-side").addClass("close");
                $(".layout-main").addClass("full-page");
                $(".layout-footer").addClass("full-page");
                $(this).addClass("close");
                $(".layout-side-arrow-icon").addClass("close");
            }
        });

        /*头部菜单按钮点击事件*/
        $(".header-menu-btn").click(function () {
            $(".layout-side").removeClass("close");
            $(".layout-main").removeClass("full-page");
            $(".layout-footer").removeClass("full-page");
            $(".layout-side-arrow").removeClass("close");
            $(".layout-side-arrow-icon").removeClass("close");

            $(".layout-side").slideToggle();
        });

        /*左侧菜单响应式*/
        $(window).resize(function () {
            var width = $(this).width();
            if (width >= 750) {
                $(".layout-side").show();
            } else {
                $(".layout-side").hide();
            }
        });

        /*皮肤选择*/
        $(".dropdown-skin li a").click(function () {
            var v = $(this).attr("data-val");
            var hrefStr = $("#layoutSkin").attr("href");
            var hrefRes = hrefStr.substring(0, hrefStr.lastIndexOf('skin/')) + 'skin/' + v + '/skin.css';
            $("#layoutSkin").attr("href", hrefRes);
            $.utils.setCookie("scclui-skin", v);
        });

        /*获取cookie中的皮肤*/
        function getSkinByCookie() {
            var v = $.utils.getCookie("scclui-skin");
            var hrefStr = $("#layoutSkin").attr("href");
            if (v == null || v == "") {
                v = "qingxin";
            }
            if (hrefStr != undefined) {
                var index = hrefStr.lastIndexOf('skin/');
                var prev = hrefStr.substring(0, index);
                var hrefRes = prev + 'skin/' + v + '/skin.css';
                $("#layoutSkin").attr("href", hrefRes);
            }
        }
        var loadFilter = function (opt) {
            var data = opt.data || {};
            var idFiled, textFiled, parentField;
            idFiled = opt.idField || 'id';
            textFiled = opt.textField || 'name';
            parentField = opt.parentField || 'parentId';
            var i, l, treeData = [], tmpMap = [];
            for (i = 0, l = data.length; i < l; i++) {
                tmpMap[data[i][idFiled]] = data[i];
            }
            for (i = 0, l = data.length; i < l; i++) {
                if (tmpMap[data[i][parentField]] && data[i][idFiled] != data[i][parentField]) {
                    if (!tmpMap[data[i][parentField]]['children'])
                        tmpMap[data[i][parentField]]['children'] = [];
                    data[i]['name'] = data[i][textFiled];
                    tmpMap[data[i][parentField]]['children'].push(data[i]);
                } else {
                    data[i]['name'] = data[i][textFiled];
                    treeData.push(data[i]);
                }
            }
            return treeData;
        };
        $('#loginOut').click(function() {
             layer.msg('确定要注销登录吗？', {
                time: 0, //不自动关闭
                    btn: [
                        '确定','取消'
                    ],
                    yes: function (index) {
                        layer.close(index);
                        app.go('/Account/LoginOut');
                    }
                 });
             });
        $(function () {
                    /*获取皮肤*/
            var skin = getSkinByCookie();
                /*菜单json*/
            var menu =[];
            $.ajax({
                url:app.url('/Admin/MenuList'),
                    type: 'post',
                        async: false,
                            dataType : 'json',
                            success: function (data) {
                    if (data && data.length > 0) {
                        var root = {
                                    "ApplicationId": "0", "ApplicationName": "导航菜单", "ParentId": "0", "Url": "", "Icon": "", "order": "1", "isHeader": "1"
                            };
                                    data.push(root);
                                    menu = data;
            } else {
                        menu =[root];
                        }
                }
                });
            menu = loadFilter({
                            data: menu,
                                idField: 'ApplicationId',
                    textField: 'ApplicationName',
                    parentField: 'ParentId'
                    });
            initMenu(menu, $(".side-menu"));
            $(".side-menu > li").addClass("menu-item");
        });
    });
});
