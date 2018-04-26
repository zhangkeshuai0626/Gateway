/// <reference path="../libs/jquery-1.11.3.min.js" />
;
define(['bootstrap', 'utils'], function () {

    //默认属性
    var defaultOptions = function (opt) {
        var options = {
            striped: true,
            method: 'post',
            data: [],
            cache: false,
            pagination: true,
            idField: undefined || 'Id',//指定主键列。
            uniqueId: opt.uniqueId || this.idField,//对每一行指定唯一标识符。
            dataType: 'json',//服务器返回的数据类型
            contentType: 'application/x-www-form-urlencoded',//发送到服务器的数据编码类型。
            escape: false,//是否转义html字符
            // '-': 'table',//不用写 JavaScript 直接启用表格。
            //  height: $(window).height() - 50,//行高
            sortName: '',
            sortOrder: 'asc',//排序方式
            ajaxOptions: {},//提交ajax请求时的附加参数，可用参数列请查看
            queryParams: function (params) {
                var form1 = this.toolbar;
                var obj = {}
                var arr = $(form1).serializeArray();
                $(arr).each(function (k, v) {
                    obj[v.name] = v.value;
                });
                $.extend(params, obj);
                return params;
            },
            options: [],
            sidePagination: 'server',
            pageSize: 15,
            pageList: [15, 30, 60, 120],
            classes: 'table table-responsive table-hover table-striped ',
            search: false,//是否启用搜索框
            searchOnEnterKey: true,//按回车触发搜索方法
            searchText: '',//初始化搜索文字。
            searchTimeOut: 500,//设置搜索超时时间。
            trimOnSearch: true,//将自动去掉搜索字符的前后空格
            showColumns: true,//是否显示内容列下拉框。
            showRefresh: true,//是否显示刷新按钮。
            showToggle: false,//是否显示切换视图（table/card）按钮。
            showPaginationSwitch: false,//是否显示切换分页按钮。
            showFullscreen: true,//是否显示全屏按钮。
            minimumCountColumns: 0,//最小隐藏列的数量。
            cardView: false,//设置为 true将显示card视图，适用于移动设备。否则为table试图，适用于pc端。
            detailView: false,//设置为 true 可以显示详细页面模式。
            //detailFormatter: function (index, row) {//格式化详细页面模式的视图。
            //    return '';
            //},
            paginationPreText: '<i class="fa fa-angle-left"></i><span> 上一页</span>',//指定分页条中上一页按钮的图标或文字。
            paginationNextText: '<span>下一页 </span><i class="fa fa-angle-right"></i>',//指定分页条中下一页按钮的图标或文字。
            clickToSelect: true,//在点击行时，自动选择 rediobox 和 checkbox。
            singleSelect: false,//设置 true 将禁止多选。
            toolbar: '#search',//一个jQuery 选择器，指明自定义的 toolbar。例如:
            buttonsToolbar: '#buttons',//按钮工具条
            checkboxHeader: true,//设置 false 将在列头隐藏全选复选框。
            maintainSelected: false,//设置为 true 在点击分页按钮或搜索按钮时，将记住checkbox的选择项。
            sortable: true,//设置为false 将禁止所有列的排序
            //rowStyle: function (row, index) {
            //    return class;
            //},
            //rowAttributes: function (row, index) {
            //}
            onLoadSuccess: function (data) {
                //加载完成之后,显示tooltip
                $("[data-toggle='tooltip']").tooltip({ placement: 'top' });
            },
            iconsPrefix: 'fa', // glyphicon of fa (font awesome)
            icons: {
                paginationSwitchDown: 'fa-angle-double-down',
                paginationSwitchUp: 'fa-angle-double-up',
                refresh: 'fa-refresh',
                toggle: 'fa-list-alt icon-list-alt',
                columns: 'fa-list',
                detailOpen: 'fa-plus',
                detailClose: 'fa-minus'
            },
        };
        return options;
    }
    var getUrl = function (actionName) {
        var str = window.location.href;
        var index = str.lastIndexOf('/');
        var prev = str.substring(0, index)
        var uri = app.url(prev + '/' + actionName);
        return uri;
    }
    var loadButtonList = function () {
        var buttonList = [];
        //1. 从服务器获取按钮
        var appid = $.utils.queryString('AppId');
        if (!appid) {
            return false;
        }
        $.utils.send({
            url: '/Application/GetButtonsByApplicationId',
            data: { ApplicationId: appid },
            async: false,
            success: function (data) {
                buttonList = data.Content;
            }
        });
        return buttonList;
    }
    var bindButtons = function (options, ckCol) {
        var el = options.el;
        //1. 从服务器读取按钮
        var btnAdd = '<a href="javascript:void(0)" id="btnAdd" class="btn btn-success" onclick="return $.bootstrapHelper.tools.add(\'' + el + '\')"><i class="fa fa-plus"> 新增</a>';
        var btnDelete = '<a href="javascript:void(0)" class="btn btn-danger"  id="btnRemove" onclick="return $.bootstrapHelper.tools.remove(\'' + el + '\')"><i class="fa fa-trash-o fa-lg"></i> 删除</a>';

        var btnQuery = '<a href="javascript:void(0)" id="btnAdd" onclick="return $.bootstrapHelper.tools.query(\'' + el + '\')" class="btn"><i class="fa fa-search"></i> 查询</a>';
        var btnReset = '<a href="javascript:void(0)" id="btnAdd" onclick="return $.bootstrapHelper.tools.reset(\'' + el + '\')" class="btn"><i class="fa fa-refresh"></i> 重置</a>';
        if (!options.buttons) {
            return ckCol;
        }
        //1. 工具栏按钮
        $(btnAdd).appendTo(options.buttonsToolbar);
        $(btnDelete).appendTo(options.buttonsToolbar);
        //2. 搜索栏按钮
        $(btnQuery).appendTo('form' + options.toolbar);
        $(btnReset).appendTo('form' + options.toolbar);
        //3. 数据行内按钮
        var col = {
            title: '操作', formatter: function (val, row, index) {
                var edit = ' <a href="javascript:void(0)" id="edit" onclick="return $.bootstrapHelper.tools.edit(\'' + row + '\',\'' + index + '\',\'' + options.idField + '\')" data-toggle="tooltip" title="编辑"><span class="fa fa-edit fa-lg edit"></span></a>&nbsp;';
                var detail = '<a href="javascript:void(0)" id="detail" onclick="return $.bootstrapHelper.tools.detail(\'' + row + '\',\'' + index + '\',\'' + options.idField + '\')" data-toggle="tooltip" title="查看"><span class="fa fa-search-plus fa-lg detail"></span></a>'

                return edit + detail;
            },
            width: 10,
            align: 'center'
        };
        ckCol.push(col);
        return ckCol;
    }
    var bootstrapHelper = {
        tools: {
            //打开新增窗口
            add: function () {
                var uri = getUrl('Add');
                $.utils.open({ title: '<i class="fa fa-plus fa-lg add"></i> 新增', content: uri });
            },
            //打开编辑窗口
            edit: function (row, index, id) {
                var uri = getUrl('Edit');
                $.utils.open({ title: '<i class="icon-pencil icon-large edit"></i> 修改信息', content: uri });
            },
            //打开详情窗口
            detail: function (row, index) {
                var uri = getUrl('Detail');
                $.utils.open({ title: '<i class="icon-camera-retro icon-large detail"></i> 查看信息', content: uri });
            },
            //查询
            query: function (table) {
                $(table).bootstrapTable('refresh');
            },
            //重置
            reset: function (toolbar, table) {
                $(toolbar)[0].reset();
                this.query(table);
            },
            //删除
            remove: function (table) {
                alert(table);
            },
        },
        table: function (opt) {
            require(['bootstrapTable'], function () {
                var el = opt.el;
                var ckCol = [{
                    title: '序号', width: 10,
                    formatter: function (val, row, index) {
                        return index + 1;
                    }
                }];
                //添加checkbox列
                if (opt.checkbox) {
                    ckCol = [{ checkbox: true, width: 10 }];
                }
                var options = defaultOptions(opt);

                //1.扩展属性
                $.extend(options, opt);
                //2. 绑定按钮
                if (options.buttons == true) {
                    ckCol = bindButtons(options, ckCol);
                }
                options.columns = $(ckCol).pushRange(options.columns);
                options.url = app.url(options.url);
                $(el).bootstrapTable(options);

            });
        }
    }
    $.extend({ bootstrapHelper: bootstrapHelper });
    return bootstrapHelper;
});