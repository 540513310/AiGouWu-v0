<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Index" %>


<%@ Register Src="Control/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>爱购物商城</title>
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
    </style>


    
 
</head>
<body>
    <form id="form1" runat="server">
    
    <!-- top -->
    <uc1:top ID="top1" runat="server" />
    <!-- one -->
    <div class="one">
        <div class="one-left">
            <div class="left">
               <%-- <div class="xt">
                </div>--%>
                <%--<div class="xm">
                </div>--%>
                <%--<h3>
                    <strong>商城公告</strong><a href="NewsList.aspx?typeid=14">更多</a></h3>--%>
                <%--<ul class="notice xx">
               <asp:Repeater runat="server" ID="re_gonggao">
               <ItemTemplate>
                  <li><a title="<%#Eval("NewsTitle")%>" href="NewsDetail.aspx?id=<%#Eval("NewsID") %>"><%#Eval("NewsTitle")%></a></li>
               </ItemTemplate>               
               </asp:Repeater>
                 
                   
                    
                 </ul>--%>
                <%--<div class="xm">
                </div>--%>
                <%--<div class="xb">
                </div>--%>
                <div class="h1">
                </div>
                <div class="xt">
                </div>
                <div class="xm">
                </div>
                <h3>
                    <strong>特价商品</strong><a href="#">更多</a></h3>
                <ul class="hotsell xx">
                    <asp:Repeater runat="server" ID="re_teijia">
                        <ItemTemplate>
                            <li><a href="ProImg/<%#Eval("smallimg") %>" rel="gb_imageset[nice_pics]">
                                <img src="ProImg/<%#Eval("smallimg") %>"></a><span> <a href="Product.aspx?proid=<%#Eval("Product_id") %>">
                                    <%#Eval("product_name")%>
                                </a></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="xm">
                </div>
                <div class="xb">
                </div>
                <div class="h1">
                </div>
                <div class="xt">
                </div>
                <div class="xm">
                </div>
                <h3>
                    <strong>新品上市</strong><a href="Product.aspx">更多</a></h3>
                <ul class="discount xx">
                    <asp:Repeater runat="server" ID="zuixinpro">
                        <ItemTemplate>
                            <li>
                            <a href="Product.aspx?proid=<%#Eval("Product_id") %>">
                                <img src="ProImg/<%#Eval("smallimg") %>"><span><%#Eval("product_name").ToString().Length > 6 ? Eval("product_name").ToString().Substring(0, 6) + "…" : Eval("product_name").ToString()%></span></a>
                           </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="xm">
                </div>
                <div class="xb">
                </div>
                <div class="h1">
                </div>
            </div>
            <div class="middle">
                <div class="xt">
                </div>
                <div class="xm">
                </div>
                <div class="rotation xx">
                    <ul class="img">
                    <%if (dt != null && dt.Rows.Count > 0)
                      {
                          for (int i = 0; i < dt.Rows.Count; i++)
                          { 
                              %>
                            <li>
                                <a href="Product.aspx?proid<%=dt.Rows[i]["Product_id"].ToString() %>">
                                 <img title="<%=dt.Rows[i]["product_name"].ToString()%>" src="ProImg/<%=dt.Rows[i]["smallimg"].ToString()%>" />
                                </a>
                            </li>

                              <%                          
                          }                      
                      }                         
                     %>
                      
                        
                    </ul>
                    <ul class="text">
                      <%
                          if (dt != null && dt.Rows.Count > 0)
                          {
                              for (int i = 0; i < dt.Rows.Count; i++)
                              { 
                                  %>
                                   <li><a href="Product.aspx?proid=<%=dt.Rows[i]["Product_id"].ToString() %>"><%=dt.Rows[i]["product_name"].ToString()%></a></li>
                                  <%
                              
                              }
                          }
                      %>
                       
                     
                    </ul>
                    
                </div>
                <div class="xm">
                </div>
                <div class="xb">
                </div>
                <div class="clew">
                    <h3>
                        放心购物</h3>
                    <span><a class="b1" href="#">诚信保障</a><a class="b2" href="#">专柜正品</a><a class="b3"
                        href="#">七天退换货</a><a class="b4" href="#">海外正品</a><a class="b5" href="#">全程保障</a></span>
                </div>
                <div class="rotationcard">
                    <div class="text">
                        <ul>
                            <li><a href="#">手机</a></li>
                            <li><a href="#">数码</a></li>
                            <li><a href="#">家电</a></li>
                            <li><a href="#">电脑硬件</a></li>
                            <li><a href="#">办公用品</a></li>
                            <li><a href="Product.aspx">软件</a></li>
                            <li><a href="Product.aspx">推荐</a></li>
                       </ul>
                    </div>
                    <div class="content">
                        <ul>
                            <!--绑定手机选项卡-->
                            <%
                                System.Data.DataRow[] mobile_dr = tb_dt.Select("type_id=2");

                                for (int i = 0; i < mobile_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=mobile_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=mobile_dr[i]["smallimg"].ToString() %>"><span><%=mobile_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=mobile_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%
                            }
                            %>
                        </ul>
                        <ul>
                            <%
                                System.Data.DataRow[] shuma_dr = tb_dt.Select("type_id=3");
                                for (int i = 0; i < shuma_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=shuma_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=shuma_dr[i]["smallimg"].ToString() %>"><span><%=shuma_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=shuma_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>

                           <ul>
                            <%
                                System.Data.DataRow[] jiadian_dr = tb_dt.Select("type_id=11");
                                for (int i = 0; i < jiadian_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=jiadian_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=jiadian_dr[i]["smallimg"].ToString() %>"><span><%=jiadian_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=jiadian_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>

                          <ul>
                            <%
                                System.Data.DataRow[] yinjian_dr = tb_dt.Select("type_id=4");
                                for (int i = 0; i < yinjian_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=yinjian_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=yinjian_dr[i]["smallimg"].ToString() %>"><span><%=yinjian_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=yinjian_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>

                           <ul>
                            <%
                                System.Data.DataRow[] bangong_dr = tb_dt.Select("type_id=5");
                                for (int i = 0; i < bangong_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=bangong_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=bangong_dr[i]["smallimg"].ToString() %>"><span><%=bangong_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=bangong_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>
                        <ul>
                            <%
                                System.Data.DataRow[] ruanjian_dr = tb_dt.Select("type_id=6");
                                for (int i = 0; i < ruanjian_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=ruanjian_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=ruanjian_dr[i]["smallimg"].ToString() %>"><span><%=ruanjian_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=ruanjian_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>
                        <ul>
                            <%
                                System.Data.DataRow[] tuijian_dr = tb_dt.Select("type_id=9");
                                for (int i = 0; i < tuijian_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=tuijian_dr[i]["Product_id"].ToString() %>">
                                <img src="ProImg/<%=tuijian_dr[i]["smallimg"].ToString() %>"><span><%=tuijian_dr[i]["product_name"].ToString()%></span></a><a
                                    href="Product.aspx?proid=<%=tuijian_dr[i]["Product_id"].ToString() %>">立即购买</a></li>
                            <%} %>
                        </ul>
                        <h3>
                            <a href="#">优惠商品100元起卖拉！</a></h3>
                    </div>
                </div>
            </div>
            <div class="one-bottom">
                <div class="prepaid">
                    <div class="title">
                     <strong>产品分类选择</strong>
                    </div>
                    <div class="content" style=" min-height:220px;">
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
                                             <li><a href="prolist.aspx?cateid=<%#Eval("id") %>">
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
                <div class="prepaid">
                <div>
                <div class="title">
               <%-- <strong>新闻中心</strong>--%>
                </div>
                </div>
             <div class="Boxnews">
                 <%--<div class="newtitle" style=" position:relative;">
                    <strong >公司新闻</strong><span style=" position:absolute; right:10px;"><a href="NewsList.aspx">更多>></a></span> 
                    </div>
                    <div>
                        <ul>
                         <asp:Repeater runat="server" ID="gongsiNews">
                         <ItemTemplate>
                          <li><a href="NewsDetail.aspx?newsid=<%#Eval("NewsID") %>"><%#Eval("NewsTitle")%></a></li>
                         </ItemTemplate>
                        </asp:Repeater>        
                        </ul>
                    </div>--%>
                </div>
                   

                      <%-- <div class="Boxnews" >
                 <div class="newtitle"  style=" position:relative;">
                        <strong>行业新闻</strong><span style=" position:absolute; right:10px;"><a href="NewsList.aspx">更多>></a></span> 
                    </div>
                    <div>
                        <ul>
                        <asp:Repeater runat="server" ID="hangyenews">
                         <ItemTemplate>
                          <li><a href="NewsDetail.aspx?newsid=<%#Eval("NewsID") %>"><%#Eval("NewsTitle")%></a></li>
                         </ItemTemplate>
                        </asp:Repeater>                      
                          
                        </ul>
                    </div>
                </div>--%>



                   <%-- <div class="Boxnews">
                 <div class="newtitle" style=" position:relative;">
                        <strong>国内新闻</strong><span style=" position:absolute; right:10px;"><a href="NewsList.aspx">更多>></a></span> 
                    </div>
                    <div>
                        <ul>
                            <asp:Repeater runat="server" ID="guoneiNews">
                         <ItemTemplate>
                          <li><a href="NewsDetail.aspx?newsid=<%#Eval("NewsID") %>"><%#Eval("NewsTitle")%></a></li>
                         </ItemTemplate>
                        </asp:Repeater>                       
                        </ul>
                    </div>
                </div>--%>
                    <div style="background-color: #d3d2d2; height: 1px">
                    </div>
                </div>
            </div>
        </div>
        <div class="right">
           <%-- <div class="tips1">
                <a href="#">
                    <img src="images/novice.gif"></a><a href="#"><img src="images/open.gif"></a></div>
            <div class="tips2">
                <ul>
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
            </div>--%>
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
                           <%
                                
                                for (int i = 0; i < tuijian_dr.Length; i++)
                                { 
                            %>
                            <li><a href="Product.aspx?proid=<%=tuijian_dr[i]["Product_id"].ToString() %>">
                             <span><%=tuijian_dr[i]["product_name"].ToString()%></span></a></li>
                            <%} %>
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
