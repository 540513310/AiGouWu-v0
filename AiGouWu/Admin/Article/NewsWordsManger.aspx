<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsWordsManger.aspx.cs" Inherits="AiGouWu.Admin.Article.NewsWordsManger" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新闻留言管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script src="../../fancybox/jquery.fancybox-1.3.4.js" type="text/javascript"></script>
    <script src="../../fancybox/jquery.easing-1.3.pack.js" type="text/javascript"></script>
    <script src="../../fancybox/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <script src="../../fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
    <link href="../../fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("a.pic").fancybox({
                'titlePosition': 'over'
            });
        });

        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
    <style type="text/css">
        .pic{ border:0px;}
        </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
        <div class="navigation">
           <span class="add"></span><b>您当前的位置：首页 &gt; 新闻管理 &gt;新闻评论审核</b>
        </div>   
        <div style="padding-bottom:10px;">
        </div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th width="10%" align="left"">新闻标题</th>
                         <th align="left">评论人</th>   
                        <th align="left">评论内容</th>
                          <th align="left">时间</th>   
                           <th align="left">审核状态</th>  
                           <th align="left">是否删除</th>     
                        <th width="70">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                       <td><%#Eval("ID")%></td>
                        <td><%#Eval("NewsTitle")%></td>
                        <td><%#Eval("UserName")%></td>
                        <td><%#Eval("LevelContent")%></td>
                        <td><%#Eval("Createdate")%></td>
                          <td><%#Eval("isShenhe")%></td>
                        <td><%#Eval("isDel")%></td>
                         <td>
                         <asp:LinkButton ID="LinkButton3" CommandName="lbNoShenHe"  CommandArgument='<%#Eval("ID") %>' runat="server">不通过</asp:LinkButton>
                         <asp:LinkButton ID="LinkButton2" CommandName="lbShenHe"  CommandArgument='<%#Eval("ID") %>' runat="server">通过</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" CommandName="lbDelete"  CommandArgument='<%#Eval("ID") %>' runat="server">删除</asp:LinkButton>
                          </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div>
        
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                onpagechanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        
        </div>
 
     </form>
</body>
</html>
