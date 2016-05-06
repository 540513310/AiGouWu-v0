<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="AiGouWu.Product" %>


<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品详细信息</title>
<link rel="stylesheet" type="text/css" href="Styles/common.css"/>
<link href="Styles/login.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/init.js"></script>
<link href="Styles/Product.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="Scripts/ValidateMessage_ZW.js" type="text/javascript"></script>
    <script src="Scripts/jquery.metadata.js" type="text/javascript"></script>
    <link href="Scripts/validateExtenderCss.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.content{}
.content h3{}
.content .main .l{float:left;}
.content .main .l ul{list-style:none;margin:0px;}
.content .main .l ul li{display:inline;border:solid 1px #eeeeee;margin:1px;}
.content .main .r{float:left;}
.content .main .r div{margin:2px;}
.sproclist{ width:140px;}
.sproclist li{ float:left;}
.spimg{ border:none;}
.spimgborder{border:1px red solid;}
.listwordsbox{  border-bottom:dotted #666 1px;}
.listwordsbox ul{ list-style:none; margin:0px; padding:0px;}
.listwordsbox ul li{ line-height:20px;  position:relative;}
</style>

<script type="text/javascript">
    $(document).ready(function () {
        $("#form1").validate();
    });

    //begin 放大镜js代码
    function MInitDiv() {
        //在目标图片load时加载，目的是将目标img的图片拷贝至放大镜
        var obj1 = document.getElementById("divBoxImage");
        var obj2 = document.getElementById(event.srcElement.id);
        obj1.src = obj2.src;

        //2012年7月22日10:03:36
        //描述:如果图片小于380*380,重新设置图片的长，宽，以满足放大镜的需要
        //作者：Tiger
        if (obj1.width <= 380) {
            obj1.width = 600;
        }

        if (obj1.height <= 380) {
            obj1.height = 700;
        }
    
    }


    function MMove() {
        //呈现放大镜
        var div = document.getElementById("divBox");
        div.style.display = "";
        var obj = document.getElementById("divBoxImage");
        //获取鼠标移动的相对位移    
        var offx = obj.width / event.srcElement.width;
        var offy = obj.height / event.srcElement.height;
        //从新设置放大镜的滚动条
        div.scrollLeft = (event.offsetX * offx);
        div.scrollTop = (event.offsetY * offy);

    }

    function MHide() {
        //隐藏放大镜
        var div = document.getElementById("divBox");
        div.style.display = "none";
    }

    function changePic() {
        getdoc("targetImage").src = event.srcElement.src;
        $(".spimg").each(function () {
            $(this).removeClass("spimg");
        })        
        $(this).addClass("spimgborder");
      
    }


    //end 放大镜js代码

    function getdoc(id) {
        return document.getElementById(id);
    }
    function showStar(index) {
        for (var i = 1; i <= 5; i++) {
            var obj = getdoc("star" + i);
            if (i <= index) {
                obj.src = "images/star.png";
            }
            else {
                obj.src = "images/unstar.png";
            }
        }
    }


    


</script>
</head>
<body>
    <form id="form1" runat="server">
<div class="one">
<div style=" margin-bottom:20px;">
    <uc1:top ID="top1" runat="server" />
    </div>
<div id="p-left">
<div class="detail_ltitle">每日商品推荐</div>
<div class="detail_l1_box">
<asp:Repeater runat="server" ID="re_renqi">
<ItemTemplate>
    <div class="detail_l1div">
        <div class="detail_l1img">
            <div>
                <a href="Product.aspx?proid=<%#Eval("product_id") %>" target="_blank">
                    <img width="100" height="100" alt="<%#Eval("product_name") %>" src="ProImg/<%#Eval("smallimg") %>"></a></div>
        </div>
        <div class="detail_l1info">
            <div class="detail_l1t">
                <a href="Product.aspx?proid=<%#Eval("product_id") %>" target="_blank"><%#Eval("product_name")%>(<%#Eval("spec")%>)</a></div>
            <div style="margin-top: 6px" id="buy_a_74724" class="market_member_price">
            </div>
        </div>
    </div>

    </ItemTemplate>
</asp:Repeater>


</div>
<br />

<div>
    <a target="_blank" href="tencent://AddContact/?fromId=45&fromSubId=1&subcmd=all&uin=540513310&fuin=2938828349&website=www.oicqzone.com">
        <img border="0" src="/images/qq客服.jpg" alt="点击这里给我发消息" title="点击这里给我发消息"/>
    </a>
</div>

</div>
    <div id="p-rigth">
        <div class="detail_r1_title">
            <h1>
                <%=dt.Rows[0]["product_name"]%></h1>
        </div>
<div>
<div class="content" style=" margin-left:20px;">
            <h3>&nbsp;</h3>
            <div class="main">
                <div class="l">
                    <img id="targetImage" src="ProImg/<%=imgsdt.Rows.Count>0?imgsdt.Rows[0]["ImgName"].ToString():"no_pic.jpg" %>" style="width:200px;height:200px;border:0px;cursor:crosshair;" 
                    onload="MInitDiv();"  onmousemove="MMove();" onmouseout="MHide();" />
                    <div style="width:200px;overflow:hidden;">
                    <ul class="sproclist">
                    <asp:Repeater runat="server"  ID="proimgs">
                    <ItemTemplate>
                    
                      <li><img id="p1" class="spimg" onclick="changePic();" src="ProImg/<%#Eval("ImgName") %>" width="60" height="60" /></li>
                    </ItemTemplate>
                    
                    </asp:Repeater>
                      


                    </ul>
                    </div>
                    <div id="divBox" style="cursor:crosshair; display:none;
                        width:380px;height:380px;overflow:hidden;position:absolute;left:600px;
                        top:200px;z-index:101;border:#3c3c3c 1px solid;">
                    <img id="divBoxImage"/>
                    </div>
                </div>
                <div class="r" style=" margin:20px;">
  
                    <div>全国24小时发货，重量500g以下免运费（非货到付款）</div>
                     <div>品牌：  <%=dt.Rows[0]["PingPai"]%></div>
                    <div>市场价格： ￥ <%=(double.Parse(dt.Rows[0]["retail_price"].ToString())*1.1).ToString("0.00")%> </div>
                    <div>商城价格： ￥<%=decimal.Parse(dt.Rows[0]["retail_price"].ToString()).ToString("0.00")%> </div>
                    <div>会员价格： ￥<%=(double.Parse(dt.Rows[0]["retail_price"].ToString()) * double.Parse(dt.Rows[0]["discount"].ToString())).ToString("0.00")%>【获得商城会员优惠价格】</div>
                    <div>产品单位： <%=dt.Rows[0]["units"]%></div>
                    <div>材    质： <%=dt.Rows[0]["material"]%></div>
                    <div>规    格： <%=dt.Rows[0]["spec"]%>×10CM </div>
                    <div>起购数量：<input  runat="server" value="1" class="{required:true,digits:true,min:1}" style=" border:solid 1px #eee; width:20px;"  type="text" id="inputnum"/> 部 </div>
                    <div>商品重量： <%=dt.Rows[0]["weight"]%></div>                   
                    <div>有效期： <%=dt.Rows[0]["expiry_date"]%></div>
                    <div>所属类型：<%=dt.Rows[0]["catalogname"]%></div>

                    <div>
                    <div>
                        <br />
                        <br />
                        <br />
                        </div><div style=" text-align:right;">
                            <asp:Label ID="lbTishi" Visible="false" ForeColor="Red" runat="server" Text="请先登录,后购买,谢谢！"></asp:Label>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="images/jieshuan.png" runat="server" 
                                onclick="ImageButton1_Click" /></div>
                    </div>
                </div>
            </div>
          
            </div>
</div>
    <div class="detail_r4_title">
        <div class="detail_r4_tcur"  onmouseover="$('#tab1').show();$('#tab2').hide();">
            商品详情</div>
        <div class="detail_r4_tdiv" onmouseover="$('#tab2').show();$('#tab1').hide();">
            <a href="#">客户点评<span style="color: #ff0000"></span></a></div>
      
    </div>
    <div id="tab1">
    <div class="detail_r4_tittle3">商品描述</div>
    <div class="detail_r4_box2"><%=dt.Rows[0]["description"]%></div>
    </div>

    <div id="tab2" style=" display:none;">

    <div class="detail_r4_tittle3">客户点评</div>
    <div class="detail_r4_box2">
    <div class="listwordsbox">
        <ul>
        <asp:Repeater runat="server" ID="Re_LevelWords">
        <ItemTemplate>
        <li><span  style=" width:300px;"><%#Eval("LevelWords")%></span><span style="position: absolute; right:90px;"><%#Eval("UserName")%></span><span style="position: absolute; right: 10px;"><%#DateTime.Parse(Eval("createdate").ToString()).ToString("yyyy-MM-dd")%></span></li>

        </ItemTemplate>
        </asp:Repeater>
            
         
        </ul>
    </div>
    <table>
   
     <tr><td>姓名：</td><td><asp:TextBox runat="server" CssClass="input required" ID="txtusername" ></asp:TextBox></td></tr>
      <tr><td>点评内容：</td><td><textarea class="textarea required"  rows="3" id="content" runat="server"></textarea></td></tr>
      <tr><td colspan="2" style="text-align:right"><asp:Button runat="server" 
              CssClass="submit" ID="btnsubmit" Text="提交" onclick="btnsubmit_Click" /></td></tr>
    </table>
    </div>
    </div>

</div>
 
</div>
    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
