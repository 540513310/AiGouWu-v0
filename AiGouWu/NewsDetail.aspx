<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="AiGouWu.NewsDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Control/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>爱购物商城-资讯详细</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta name="keywords" content="爱购物商城"/>
   
    <meta name="author" content="">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Styles/common.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/index.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/init.js"></script>
    <link href="Styles/Product.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="Scripts/ValidateMessage_ZW.js" type="text/javascript"></script>
    <link href="Scripts/validateExtenderCss.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
     .cattitle{ font-weight:bold; margin-top:20px;}
     .childitem{ margin-top:5px; width:200px;}
     .childitem li{ display:inline;}
     .childitem li a:hover{color:Red;}
     
     .newslist{border-bottom:dotted 1px #eee;   margin:10px auto; color:#666; clear:both;}
     .newslist div{ float:left; display:block; margin:5px;}
   
      .proInfo p{ margin-bottom:10px;}
 
        .fl{ float:left}
        .red{ color:Red; font-weight:bold;}
        .w60{ width:60px;}
        .w360{ width:360px;}
        .w200{ width:200px;}
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
      .newsnav{}
      .newscontent{border:solid 1px #eee;  background-color:#fff; clear:both; margin:10px auto;}
      .newstitle{ text-align:center; line-height:30px;}
      .newsauthor{ text-align:center; position:relative; border-bottom:solid 1px #ccc; line-height:50px; margin-bottom:30px;}
      .newsdetail{ line-height:25px; margin-left:10px;}
      .newsbottom{text-align:right; line-height:50px;}
      .newsbottom a:hover{ text-decoration:none; color:Red; }
    </style>

    

    <script type="text/javascript">

        function check() {


            var username = document.getElementById("txtusername");

            var content = document.getElementById("content");
           if (username.value == "") {
              
                alert('用户名不能为空');
                return false;
            }
            if (content.value == "") {
              
                alert('评论内容不能为空');
                return false;
            }
            return true;

        }

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


            $("#fbig").click(function () {
                $(".newsdetail").css("font-size", "16px");

            });

            $("#fmiddle").click(function () {
                $(".newsdetail").css("font-size", "14px");

            });

            $("#fsmall").click(function () {
                $(".newsdetail").css("font-size", "12px");

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
        

        <!--导航-->

          <div id="searchlist"  class="newsnav">
          <a href="Index.aspx">首页>></a><a href="NewsList.aspx">资讯列表>></a><a href="NewsDetail.aspx">详细</a>


          </div>

            <!--新闻详细-->
          <div id="prolistresult" style=" z-index:-1;">
                  <div class="prepaid" style="clear:both; height:auto; z-index:-1;">
                    <div class="title">
                     <strong>新闻详细内容</strong>
                    </div>
                    <div class="newscontent">                    
                     <div class="newstitle"><h3><%=dt.Rows[0]["NewsTitle"].ToString()%></h3></div>
                     <div class="newsauthor">
                       <span>作者：<%=dt.Rows[0]["Author"].ToString()%></span><span style=" position:absolute; right:10px;">[<%=dt.Rows[0]["CreateDate"].ToString()%>]</span>
                     </div>
                     <div class="newsdetail">
                      <span>
                        <%=dt.Rows[0]["NewsContent"].ToString()%>
                      </span>
                     </div>
                  
               



          

             
                     
                     <div style=" clear:both;" class="newsbottom">
                      <span><a  href="#">文字大小:<span id="fbig">【大】</span><span id="fmiddle">【中】</span><span id="fsmall">【小】</span> </a><a href="#"><span onclick="window.external.AddFavorite(location.href, document.title)">【收藏本文章】</span></a><a href="#"><span onclick="window.print()">【打印】</span></a></span>
                       
                     </div>
                     <div>
                      <div>
                          <div class="detail_r4_tittle3">
                              网友点评</div>
                          <div class="detail_r4_box2">
                              <div class="listwordsbox">
                                  <ul>
                                      <asp:Repeater runat="server" ID="Re_LevelWords">
                                          <ItemTemplate>
                                              <li><span style="width: 200px;">
                                                  <%#Eval("LevelContent")%></span><span style="position: absolute; right: 130px;">
                                                      <%#Eval("UserName")%></span><span style="position: absolute; right: 50px;">
                                                          <%#DateTime.Parse(Eval("createdate").ToString()).ToString("yyyy-MM-dd")%>
                                                  </span></li>
                                          </ItemTemplate>
                                      </asp:Repeater>
                                  </ul>
                              </div>
                              <table>
                                  <tr>
                                      <td>
                                          姓名：
                                      </td>
                                      <td>
                                          <asp:TextBox runat="server" CssClass="input" ID="txtusername"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          点评内容：
                                      </td>
                                      <td>
                                          <textarea class="textarea" rows="3" id="content" runat="server"></textarea>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td colspan="2" style="text-align: right">
                                          <asp:Button runat="server" CssClass="submit" ID="btnsubmit" OnClientClick="return check();" Text="提交" OnClick="btnsubmit_Click" />
                                          <asp:Label runat="server" ID="lbShow" ForeColor="red" Visible="false" Text="评论提交成功，谢谢"></asp:Label>
                                      </td>
                                  </tr>
                              </table>
                          </div>

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
