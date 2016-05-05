<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="AiGouWu.Control.top" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" language="javascript">          var GB_ROOT_DIR = "../greybox/";    </script>
    
    <script type="text/javascript" src="../greybox/AJS.js"></script>
    <script type="text/javascript" src="../greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="../greybox/gb_scripts.js"></script>
    <link href="../greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript">
        function showlogin() {
            GB_showCenter("用户登录", "Login.aspx", 420, 320);
        }
    </script>

<div class="top">
    <div class="topsl" id="tops_1">

        <span><a href="ShoppingCart.aspx">购物车<strong><%=sum.ToString()%></asp:Label></strong>个商品</a> | <a href="#">我的收藏</a></span><a
            href="#"  onclick="showlogin()"  class="signin">[ 登录 ]</a> | <a href="Register.aspx">
                [ 免费注册 ]</a>
    </div>
    <div class="topsr">
        <div class="user">
            <dl>
                <dt><a href="ShoppingOrdersList.aspx">我的爱购物</a></dt>
                <dd>
                    <a href="#">我购买的商品</a><a href="#">我的收藏</a><a href="#">最新降价提醒</a><a href="#">短消息(<strong>22</strong>)条</a></dd></dl>
        </div>
        <div class="text">
            |<a href="SupplierApplay.aspx">供应商加盟</a>|<span runat="server" id="lbUser" visible="false" style="color:Red;">你好:<asp:Label runat="server"  ID="lbUserName"></asp:Label></span></div>
        <div class="help">
            <dl>
                <dt><a href="#">帮助</a></dt>
                <dd>
                    <a href="#">支付方式</a><a href="#">配送范围</a><a href="#">客户服务</a></dd></dl>
        </div>
    </div>
    <div class="topClose">
        <a title="点击关闭" href="javascript:void(0)">关闭</a></div>
</div>
<div class="topOpen">
    <a title="点击打开" href="javascript:void(0)">打开</a></div>
<!-- head -->
<div class="head">
    <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <a title="" href="index.aspx">爱购物商城</a></h1>
    <div class="search">
        <asp:TextBox ID="searchInput" CssClass="input" runat="server" MaxLength="20" type="text"
            name="searchInput" />
            <asp:Button runat="server"  ID="btnsearch"  CssClass="BUTTON" Text="商品搜索" 
            onclick="btnsearch_Click"/>
        
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" TargetControlID="searchInput"
            ServicePath="~/AutoSearchKeyWords.asmx" ServiceMethod="GetProList" CompletionSetCount="10"
            CompletionInterval="10" MinimumPrefixLength="1" runat="server">
        </cc1:AutoCompleteExtender>
    </div>
    <div class="tags">
        <a href="prolist.aspx?cateid=52">IPad</a><a href="prolist.aspx?cateid=65">空调</a><a href="prolist.aspx?cateid=42">智能机</a>
    </div>
</div>
<!-- nav -->
<%--<div class="nav">
    <span class="icon"></span><span class="navl"></span><span class="navr"></span>
    <ul>
     
        <li><a href="../Index.aspx">首 页</a></li>
        <li><a href="prolist.aspx?typeid=8">特价商品</a></li>
        <li><a href="prolist.aspx?typeid=10">促销热卖</a></li>
        <li><a href="NewsList.aspx">行业资讯</a></li>
        <li><a href="prolist.aspx?typeid=9">每日推荐</a></li>
        <li><a href="#">爱购物社区</a></li>
         <li><a href="prolist.aspx?typeid=7">新品上市</a></li>
        </ul>
</div>--%>

