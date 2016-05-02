jQuery.extend(
jQuery.validator.messages, {
required: "<em>*</em>",
remote: "<em>请修正该字段</em>",
email: "<em>请输入正确格式的电子邮件</em>",
url: "<em>请输入合法的网址</em>",
date: "<em>请输入合法的日期</em>",
dateISO: "<em>请输入合法的日期 (如：2011-11-02)</em>",
number: "<em>请输入合法的数字</em>",
digits: "<em>只能输入整数</em>",
creditcard: "<em>请输入合法的信用卡号</em>",
equalTo: "<em>请再次输入相同的值</em>",
accept: "<em>请输入拥有合法后缀名的字符串</em>",
maxlength: $.validator.format("<em>请输入一个长度最多是 {0} 的字符串</em>"),
minlength: $.validator.format("<em>请输入一个长度最少是 {0} 的字符串</em>"),
rangelength: $.validator.format("<em>请输入一个长度介于 {0} 和 {1} 之间的字符串</em>"),
range: $.validator.format("<em>请输入一个介于 {0} 和 {1} 之间的值</em>"),
max: $.validator.format("<em>请输入一个最大为 {0} 的值</em>"),
min: $.validator.format("<em>请输入一个最小为 {0} 的值</em>")
});

