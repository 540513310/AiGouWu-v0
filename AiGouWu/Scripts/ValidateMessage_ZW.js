jQuery.extend(
jQuery.validator.messages, {
required: "<span class='error'>必须填写</span>",
remote: "<span class='error'>请修正该字段</span>",
email: "<span class='error'>请输入正确格式的电子邮件</span>",
url: "<span class='error'>请输入合法的网址</span>",
date: "<span class='error'>请输入合法的日期</span>",
dateISO: "<span class='error'>请输入合法的日期 (如：2011-11-02)</span>",
number: "<span class='error'>请输入合法的数字</span>",
digits: "<span class='error'>只能输入整数</span>",
creditcard: "<span class='error'>请输入合法的信用卡号</span>",
equalTo: "<span class='error'>请再次输入相同的值</span>",
accept: "<span class='error'>请输入拥有合法后缀名的字符串</span>",
maxlength: $.validator.format("<span class='error'>请输入一个长度最多是 {0} 的字符串</span>"),
minlength: $.validator.format("<span class='error'>请输入一个长度最少是 {0} 的字符串</span>"),
rangelength: $.validator.format("<span class='error'>请输入一个长度介于 {0} 和 {1} 之间的字符串</span>"),
range: $.validator.format("<span class='error'>请输入一个介于 {0} 和 {1} 之间的值</span>"),
max: $.validator.format("<span class='error'>请输入一个最大为 {0} 的值</span>"),
min: $.validator.format("<span class='error'>请输入一个最小为 {0} 的值</span>")
});

