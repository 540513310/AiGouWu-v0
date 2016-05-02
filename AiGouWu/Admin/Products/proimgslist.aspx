<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proimgslist.aspx.cs" Inherits="AiGouWu.Admin.Products.proimgslist" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>类别管理</title>
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
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 86px;
        }
    </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
        <div class="navigation">
           <span class="add"><a href="proimgslist.aspx">添加产品图片</a></span><b>您当前的位置：首页 &gt; 产品图片管理 &gt;图片列表&发布</b>
        </div>   
        <div style="padding-bottom:10px;">
            <table class="style1">
                <tr>
                    <td class="style2">
                        产品名称</td>
                    <td>
                        <asp:Label ID="lbProname" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        图片上传</td>
                    <td>
                        <asp:FileUpload ID="fp_img" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="上传" onclick="btnUpload_Click" />
                        <asp:Image ID="proimg" Width="100px" Height="100px" Visible="false"  runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th width="10%" align="left"">产品名称</th>
                        <th align="left">图片</th>     
                        <th width="150">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">    
                          <%# Eval("imgID")%>
                        </td>
                        <td>
                          <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                          <%# Eval("product_name")%>
                        </td>
                        <td>
                          <a id="A1" href='../../ProImg/<%#Eval("ImgName") %>'   class="pic"  >
                                <img id="Img1" src='../../ProImg/<%#Eval("ImgName") %>'  height="35"
                                    width="35" /></a>
                       </td>                      
                        <td align="left">
                            <span>
                                <asp:LinkButton ID="LinkButton1" CommandName="lbEdit" CommandArgument='<%#Eval("imgID") %>' runat="server">修改</asp:LinkButton></span>                     
                            <span> <asp:LinkButton ID="LinkButton2" CommandName="lbDelete"  CommandArgument='<%#Eval("imgID") %>' runat="server">删除</asp:LinkButton></span>                            
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
