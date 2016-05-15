<%@ Page Language="C#"  AutoEventWireup="true"  CodeBehind="prolist.aspx.cs" ValidateRequest="false"  Inherits="AiGouWu.prolist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Control/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>爱购物商城-产品分类列表</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta name="keywords" content="爱购物商城">
    <meta name="author" content="">
    <link rel="stylesheet" type="text/css" href="Styles/common.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/index.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/init.js"></script>

    <style type="text/css">
     .cattitle{ font-weight:bold; margin-top:20px;}
     .childitem{ margin-top:5px; width:200px;}
     .childitem li{ display:inline;}
     .childitem li a:hover{color:Red;}
     
     .list{border-bottom:dotted 1px #eee;   margin:10px auto; color:#666; clear:both; height:120px;}
     .list div{ float:left; display:block; margin:5px;}
   
      .proInfo p{ margin-bottom:10px;}
 
        .fl{ float:left}
        .red{ color:Red; font-weight:bold;}
        .w60{ width:60px;}
        .w360{ width:360px;}
        .w250
        {
            width: 250px;
        }
        .w380
        {
            width: 380px;
        }
        .wh380
        {
            width: 380px;
            height: 50px;
        }
        .submit
        {
            background: url(Admin/Images/button_submit.gif) repeat-x #e3f1fa;
            border: 1px solid #aed0ea;
            padding: 0px 10px;
            line-height: 24px;
            color: #3d80b3;
            cursor: pointer;
            height: 24px;
        }
        .input
        {
            padding: 0px 3px;
            border: 1px solid #d1d1d1;
            background: url(Admin/Images/input_bg.jpg) repeat-x;
            height: 18px;
            line-height: 18px;
            font-size: 12px;
            color: #999;
        }
        
        .select1
        {
            padding: 1px;
            border: 1px solid #CDCDCD;
            background: #FDFEEF;
            height: 20px;
        }
        .keyword
        {
            border: 1px solid #CDCDCD;
            background: #FDFEEF;
            height: 20px;
            line-height: 20px;
            overflow: hidden;
        }
    </style>

    
    <style type="text/css">
    /*CSS scott style pagination*/

DIV.scott {
	PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; MARGIN: 3px; PADDING-TOP: 3px; TEXT-ALIGN: center
}
DIV.scott A {
	BORDER-RIGHT: #ddd 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #ddd 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #ddd 1px solid; COLOR: #88af3f; MARGIN-RIGHT: 2px; PADDING-TOP: 2px; BORDER-BOTTOM: #ddd 1px solid; TEXT-DECORATION: none
}
DIV.scott A:hover {
	BORDER-RIGHT: #85bd1e 1px solid; BORDER-TOP: #85bd1e 1px solid; BORDER-LEFT: #85bd1e 1px solid; COLOR: #638425; BORDER-BOTTOM: #85bd1e 1px solid; BACKGROUND-COLOR: #f1ffd6
}
DIV.scott A:active {
	BORDER-RIGHT: #85bd1e 1px solid; BORDER-TOP: #85bd1e 1px solid; BORDER-LEFT: #85bd1e 1px solid; COLOR: #638425; BORDER-BOTTOM: #85bd1e 1px solid; BACKGROUND-COLOR: #f1ffd6
}
DIV.scott SPAN.current {
	BORDER-RIGHT: #b2e05d 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #b2e05d 1px solid; PADDING-LEFT: 5px; FONT-WEIGHT: bold; PADDING-BOTTOM: 2px; BORDER-LEFT: #b2e05d 1px solid; COLOR: #fff; MARGIN-RIGHT: 2px; PADDING-TOP: 2px; BORDER-BOTTOM: #b2e05d 1px solid; BACKGROUND-COLOR: #b2e05d
}
DIV.scott SPAN.disabled {
	BORDER-RIGHT: #f3f3f3 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #f3f3f3 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #f3f3f3 1px solid; COLOR: #ccc; MARGIN-RIGHT: 2px; PADDING-TOP: 2px; BORDER-BOTTOM: #f3f3f3 1px solid
}


    
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#spanhide").click(function () {
                if ($(this).text() == "收起") {
                    $("#catacontent").hide(1000);
                    $(this).html("显示");
                } else {
                    $("#catacontent").show(1000);
                    $(this).html("收起");
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
 
    <!-- top -->
    <uc1:top ID="top1" runat="server" />
    <!-- one -->
    <div class="one">
        <div class="one-left">
        <!--产品类型绑定-->
            <div id="catalist">
                 <div class="prepaid">
                    <div class="title" style=" position:relative;">
                     <strong>产品分类选择</strong><span id="spanhide" style="position:absolute; right:10px;">收起</span>
                    </div>
                    <div id="catacontent" class="content" style=" min-height:220px; background-color:#fff;">
                       <div>               
                        <asp:DataList runat="server" ID="datalist_catlist" RepeatColumns="3" 
                               RepeatDirection="Horizontal" onitemdatabound="datalist_catlist_ItemDataBound">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                         <div class="cattitle"><%#Eval("catalogname")%></div>
                          <div>
                                 <ul id="childitem" class="childitem">
                                     <asp:Repeater runat="server" ID="catitem">
                                         <ItemTemplate>
                                             <li><a href="prolist.aspx?cateid=<%#Eval("id") %>" target="_blank" >
                                                 <%#Eval("catalogname")%></a></li>
                                         </ItemTemplate>
                                     </asp:Repeater>
                                 </ul>
                             </div>


                        </ItemTemplate>
                        </asp:DataList>



                       </div>
                    </div>
                    <div style="background-color: #d3d2d2; height: 1px">
                    </div>
           
                 </div>

            </div>

        <!--产品信息筛选模块-->

          <div id="searchlist">
                  <div class="prepaid">
                    <div class="title">
                     <strong>产品筛选</strong>
                    </div>
                    <div   style="border:solid 1px #eee; z-index:1000; min-height:50px; background-color:#fff;">
                    <table style=" width:100%; margin-top:10px;">
                    <tr>
                    <td>价格:
                        <asp:DropDownList ID="ddlPriceList" CssClass="select1" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlPriceList_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="由低到高" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="由高到低"></asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    <td>上架时间:<asp:DropDownList CssClass="select1" runat="server" ID="ddlDate" 
                            AutoPostBack="True" onselectedindexchanged="ddlDate_SelectedIndexChanged">
                       <asp:ListItem Value="0">由近到远</asp:ListItem>
                        <asp:ListItem Value="1">由远到近</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style=" text-align:right; z-index:1001;" >关键字:<asp:TextBox ID="keywords" CssClass="keyword" runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender  ID="AutoCompleteExtender1" ServicePath="AutoSearchKeyWords.asmx" ServiceMethod="GetProList" CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" TargetControlID="keywords" runat="server">
                        </cc1:AutoCompleteExtender>
                        <asp:Button runat="server" CssClass="submit" id="btnSearch"  Text="搜索" 
                            onclick="btnSearch_Click"/></td>
                    </tr>
                    </table>
                    </div>
                  
                  </div>
          </div>

            <!--产品列表模块-->
          <div id="prolistresult">
                  <div class="prepaid" style="clear:both; height:auto;">
                    <div class="title">
                     <strong>产品列表(搜索结果)</strong>
                    </div>
                    <div   style="border:solid 1px #eee;  background-color:#fff; clear:both; margin:10px auto;">                    
                  <asp:Repeater runat="server" ID="proslist">
                   <ItemTemplate>
                       <div class="list">                        
                         <div><a href="Product.aspx?proid=<%#Eval("Product_id") %>"><img src="ProImg/<%#Eval("smallimg") %>" width="100px" height="100px" /> </a></div>
                         <div class="w360 proInfo">
                           <h3><a href="Product.aspx?proid=<%#Eval("Product_id") %>"><%#Eval("product_name")%></a></h3>
                           <p>
                            <span>产品简介:</span><span><%#Eval("description").ToString().Replace("<img>","")%></span></p>
                         </div>
                         <div class="w60">
                          <span style=" text-decoration:line-through;">￥<%#decimal.Parse(Eval("retail_price").ToString()).ToString("0.00")%></span></div>
                         <div class="w60 red">
                          <span ><%# (decimal.Parse(Eval("discount").ToString())*decimal.Parse(Eval("retail_price").ToString())).ToString("0.00")%></span>
                         </div>
                          <div class="w60">
                             <a href="#" class="fl"><img  src="images/list_collect.gif"/></a>   <a href="Product.aspx?id=<%#Eval("Product_id") %>" class="fl"><img  src="images/list_detail.gif"/></a>
                             <a href="#"><img  src="images/list_buy.gif"/></a>
                          </div>                     
                     </div>
                   </ItemTemplate>
                   
                  </asp:Repeater>
         

             
                     
                     <div style=" clear:both;">
                      <div class="scott">
                          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                              onpagechanged="AspNetPager1_PageChanged">
                          </webdiyer:AspNetPager>
                       </div>
                     
                     </div>




                    </div>
                  
                  </div>
          </div>




          </div>

        <div class="right">
            <div class="tips1">
                <a href="#">
                    <img src="images/novice.gif"></a><a href="#"><img src="images/open.gif"></a></div>
            <div class="tips2">
                <ul>
                    <li><a href="#">收藏 + 购物车，逛街搜店更便捷l>
                    <li><a href="#">收藏 + 购物车，逛街搜店更便捷</a></li>
                    <li><a href="#">认准标识，精选实力卖家任您选择</a></li>
                    <li><a href="#">一分钱”轻松体验有啊网购流程</a></li>
                    <li><a href="#">尽情挥洒你的创意，共建百度有啊</a></li>
                    <li><a href="#">认准标识，精选实力卖家任您选择</a></li></ul>
            </div>
            <div class="tips3">
                <ul>
                    <li class="b1"><a href="#">先验货再付款，交易更安全</a></li>
                    <li class="b2"><a href="#">信用诚实可靠，品质有保障</a></li>
                    <li class="b3"><a href="#">精选诚信商户，卖家可信赖</a></li>
                    <li class="b4"><a href="#">强大客服支持，购物更放心</a></li></ul>
            </div>
            <div class="tips4">
                <a class="b1" title="交易安全" href="#">交易安全</a> <a class="b2" title="免费注册" href="#">免费注册</a>
                <a class="b3" title="1分钱体验" href="#">1分钱体验</a>
            </div>
            <div class="prepaid">
                <div class="title">
                    <strong>人气排行</strong>
                </div>
                <div class="content">
                    <ul>
                    <asp:Repeater runat="server" ID="re_renqi">
                    <ItemTemplate>
                     <li><a href="Product.aspx?proid=<%#Eval("product_id") %>"><%#Eval("product_name")%></a></li>
                    </ItemTemplate>                   
                    </asp:Repeater>                      
                    </ul>
                </div>
                <div class="b1">
                </div>
            </div>
            <div class="prepaid">
                <div class="title">
                    <strong>爱购物推荐产品</strong>
                </div>
                <div class="content">
                    <ul>

                    <asp:Repeater ID="retuijian" runat="server">
                     <ItemTemplate >
                       <li><a href="Product.aspx?proid=<%#Eval("Product_id") %>">
                             <span><%#Eval("product_name")%></span></a></li>

                     </ItemTemplate>
                    </asp:Repeater>
                       
                    </ul>
                </div>
                <div class="b1">
                </div>
            </div>
            <div class="prepaidimg">
                <a href="#">
                    <img src="images/ad.jpg"></a></div>
        </div>
    </div>
    &nbsp;<uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
