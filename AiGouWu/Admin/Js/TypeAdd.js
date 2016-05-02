var count = 0;
$(document).ready(function () {
    $("#loading").hide()
});

function TypeAdd() {
    $("#btnaddtype").hide();
    $("#loading").show();
    var txtName = $("#txtName");

    $.ajax({
        url: "TypeAdd.aspx?typename=" + encodeURI(txtName.val())+ "",
        type: "post",
        datatype: "text",
        success: function (returnValue) {
            if (returnValue != "false") {
                $("#newtype").hide();
                $("#showMes").hide();
                $("#divTypeManger").remove();
                $("#graybackground").remove();
                $("#showMes").hide();
                window.location.href = window.location.href;
            }
            else {
                count = count + 1;
                $("#loading").hide();
                $("#btnaddtype").show();
                $("#showMes").show();
                $("#showMes").html("<font color=red>添加失败，请检查后重试!(" + count + "次)</font>");
            }
        }
    })
}