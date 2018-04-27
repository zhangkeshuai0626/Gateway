///扩展语言包
$.extend($.validator.messages, {
    required: "这是必填字段",
    remote: "请修正此字段",
    email: "请输入有效的电子邮件地址",
    url: "请输入有效的网址",
    date: "请输入有效的日期",
    dateISO: "请输入有效的日期 (YYYY-MM-DD)",
    number: "请输入有效的数字",
    digits: "只能输入数字",
    creditcard: "请输入有效的信用卡号码",
    equalTo: "你的输入不相同",
    extension: "请输入有效的后缀",
    maxlength: $.validator.format("最多可以输入 {0} 个字符"),
    minlength: $.validator.format("最少要输入 {0} 个字符"),
    rangelength: $.validator.format("请输入长度在 {0} 到 {1} 之间的字符串"),
    range: $.validator.format("请输入范围在 {0} 到 {1} 之间的数值"),
    max: $.validator.format("请输入不大于 {0} 的数值"),
    min: $.validator.format("请输入不小于 {0} 的数值")
});

///扩展方法
/*****************************************************************
                  jQuery Validate扩展验证方法  (linjq)       
*****************************************************************/
jQuery.validator.addMethod("zero", function (value, element) {
    value = parseInt(value);
    return this.optional(element) || value == 0;
}, "整数必须为0");

// 判断整数value是否大于0
jQuery.validator.addMethod("integer", function (value, element) {
    value = parseInt(value);
    return this.optional(element) || value > 0;
}, "整数必须大于0");
// 判断浮点数value是否大于或等于0
jQuery.validator.addMethod("float", function (value, element) {
    value = parseFloat(value);
    return this.optional(element) || value >= 0;
}, "浮点数必须大于或等于0");
// 只能输入[0-9]数字
jQuery.validator.addMethod("digits", function (value, element) {
    return this.optional(element) || /^\d+$/.test(value);
}, "只能输入0-9数字");

// 判断中文字符 
jQuery.validator.addMethod("chinese", function (value, element) {
    return this.optional(element) || /^[\u0391-\uFFE5]+$/.test(value);
}, "只能包含中文字符。");

// 判断英文字符 
jQuery.validator.addMethod("english", function (value, element) {
    return this.optional(element) || /^[A-Za-z]+$/.test(value);
}, "只能包含英文字符。");

// 手机号码验证    
jQuery.validator.addMethod("mobile", function (value, element) {
    var length = value.length;
    return this.optional(element) || (length == 11 && /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/.test(value));
}, "请正确填写您的手机号码。");
// 电话号码验证    
jQuery.validator.addMethod("phone", function (value, element) {
    var tel = /^(\d{3,4}-?)?\d{7,9}$/g;
    return this.optional(element) || (tel.test(value));
}, "请正确填写您的电话号码。");

// 联系电话(手机/电话皆可)验证   
jQuery.validator.addMethod("isTel", function (value, element) {
    var length = value.length;
    var mobile = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
    var tel = /^(\d{3,4}-?)?\d{7,9}$/g;
    return this.optional(element) || tel.test(value) || (length == 11 && mobile.test(value));
}, "请正确填写您的联系方式");

// 匹配qq      
jQuery.validator.addMethod("qq", function (value, element) {
    return this.optional(element) || /^[1-9]\d{4,12}$/;
}, "匹配QQ");

// 邮政编码验证    
jQuery.validator.addMethod("zipCode", function (value, element) {
    var zip = /^[0-9]{6}$/;
    return this.optional(element) || (zip.test(value));
}, "请正确填写您的邮政编码。");

// 匹配密码，以字母开头，长度在6-12之间，只能包含字符、数字和下划线。      
jQuery.validator.addMethod("pwd", function (value, element) {
    return this.optional(element) || /^[a-zA-Z]\\w{6,12}$/.test(value);
}, "以字母开头，长度在6-12之间，只能包含字符、数字和下划线。");

// 身份证号码验证
jQuery.validator.addMethod("idCard", function (value, element) {
    //var idCard = /^(\d{6})()?(\d{4})(\d{2})(\d{2})(\d{3})(\w)$/;   
    return this.optional(element) || isIdCardNo(value);
}, "请输入正确的身份证号码。");

// IP地址验证   
jQuery.validator.addMethod("ip", function (value, element) {
    return this.optional(element) || /^(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$/.test(value);
}, "请填写正确的IP地址。");

// 字符验证，只能包含中文、英文、数字、下划线等字符。    
jQuery.validator.addMethod("stringCheck", function (value, element) {
    return this.optional(element) || /^[a-zA-Z0-9\u4e00-\u9fa5-_]+$/.test(value);
}, "只能包含中文、英文、数字、下划线等字符");

// 判断是否为合法字符(a-zA-Z0-9-_)
jQuery.validator.addMethod("isRightfulString", function (value, element) {
    return this.optional(element) || /^[A-Za-z0-9_-]+$/.test(value);
}, "判断是否为合法字符(a-zA-Z0-9-_)");
// 判断是否包含中英文特殊字符，除英文"-_"字符外
jQuery.validator.addMethod("isContainsSpecialChar", function (value, element) {
    var reg = RegExp(/[(\ )(\`)(\~)(\!)(\@)(\#)(\$)(\%)(\^)(\&)(\*)(\()(\))(\+)(\=)(\|)(\{)(\})(\')(\:)(\;)(\')(',)(\[)(\])(\.)(\<)(\>)(\/)(\?)(\~)(\！)(\@)(\#)(\￥)(\%)(\…)(\&)(\*)(\（)(\）)(\—)(\+)(\|)(\{)(\})(\【)(\】)(\‘)(\；)(\：)(\”)(\“)(\’)(\。)(\，)(\、)(\？)]+/);
    return this.optional(element) || !reg.test(value);
}, "含有中英文特殊字符");


//身份证号码的验证规则
function isIdCardNo(num) {
    //if (isNaN(num)) {alert("输入的不是数字！"); return false;} 
    var len = num.length, re;
    if (len == 15)
        re = new RegExp(/^(\d{6})()?(\d{2})(\d{2})(\d{2})(\d{2})(\w)$/);
    else if (len == 18)
        re = new RegExp(/^(\d{6})()?(\d{4})(\d{2})(\d{2})(\d{3})(\w)$/);
    else {
        //alert("输入的数字位数不对。"); 
        return false;
    }
    var a = num.match(re);
    if (a != null) {
        if (len == 15) {
            var D = new Date("19" + a[3] + "/" + a[4] + "/" + a[5]);
            var B = D.getYear() == a[3] && (D.getMonth() + 1) == a[4] && D.getDate() == a[5];
        }
        else {
            var D = new Date(a[3] + "/" + a[4] + "/" + a[5]);
            var B = D.getFullYear() == a[3] && (D.getMonth() + 1) == a[4] && D.getDate() == a[5];
        }
        if (!B) {
            //alert("输入的身份证号 "+ a[0] +" 里出生日期不对。"); 
            return false;
        }
    }
    if (!re.test(num)) {
        //alert("身份证最后一位只能是数字和字母。");
        return false;
    }
    return true;
}
;



$.validator.setDefaults({
    errorClass: 'form-error',//错误标签的class类，用于自定义样式
    onfocusout: function (element) {
        $(element).valid();
    },
    onChange: function (element) {
        $(element).valid();
    },
    //errorPlacement: function (error, element) {//自定义错误提示位置，超级有用,看下图3
    //    var position = element.attr("position");
    //    if (position) {
    //        error.css({ "left": position.split(",")[0] + "px", "top": position.split(",")[1] + "px" });
    //    }
    //    element.parent().css({ "position": "relative" }).append(error);
    //}
    errorPlacement: function (error, element) {
        error.addClass('tooltip tooltip-inner arrow-left');
        if (element.is(":radio")) {
            error.appendTo(element.parent().next().next());
        } else if (element.is(":checkbox")) {
            error.appendTo(element.next());
        } else {
            element.after(error);
        }
        var pos = $.extend({}, element.offset(), {
            width: element.outerWidth(),
            height: element.outerHeight()
        }),
          actualWidth = error.outerWidth(),
          actualHeight = error.outerHeight();
        if ((pos.top - actualHeight) < 0) { actualHeight = 0; pos.width += 10; }//如果输入框距离顶端为0情况把提示放右边  
        if (element.parents(".blockPage").attr("class") == "blockUI blockMsg blockPage") {//如果是弹出框的，那么设置如下  
            error.css({ display: 'block', opacity: '0.6', left: 300, top: pos.top - $(document).scrollTop() - actualHeight - 100, "border-left": '0px' });
        }
        else if (element.is(":radio")) {//类型为radio的显示如下  
            error.css({ display: 'block', opacity: '0.6', top: pos.top - actualHeight, left: pos.left + pos.width / 2 });
        } else {//其他均为以下显示  
            error.css({ display: 'block', opacity: '0.6', top: pos.top - actualHeight, left: pos.left + pos.width - 10 });
        }

    },
    highlight: function (element, errorClass) {
        //高亮显示  
        $(element).addClass(errorClass);
        $(element).parents('li:first').children('label').addClass(errorClass);
    },
    unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass);
        $(element).parents('li:first').children('label').removeClass(errorClass);
    }
});



$.metadata.setType('attr', 'data-validate');//这句就是告诉validate，写在HTML标签中的那个属性是验证规则
$('form,input,textarea,select').validate({ meta: "validType" });