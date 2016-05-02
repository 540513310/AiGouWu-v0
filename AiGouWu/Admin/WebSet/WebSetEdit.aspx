<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSetEdit.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Admin.WebSet.WebSetEdit" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站参数配置</title>

    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script src="../Js/DateControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                success: function(label) {
                              //正确时的样式
                              label.text(" ").addClass("success");
                                       }
                        });         
        });
    </script>
    <style type="text/css">
        .style2
        {
            width: 89px;
        }
        .style4
        {
            width: 127px;
        }
        </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
          <input id="Type_ID"  runat="server" type="hidden" /> 
    <div class="navigation">
      <span class="back"><a href="WebSetDetail.aspx">返回</a></span><b>您当前的位置：首页 &gt; 网站配置管理 &gt; 网站参数配置</b>
    </div>
    <div style="padding-bottom:10px;"></div>


      <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="msgtable">
    <tr>
      <td>
          网站名</td>
      <td>     
      <asp:TextBox ID="txtWebName" CssClass="input" runat="server"></asp:TextBox>  
   
        </td>
      <td>网站域名</td>
      <td>
        <asp:TextBox ID="txtWebUrl" CssClass="input" runat="server"></asp:TextBox>  

    
    
        </td>
    </tr>
    <tr>
      <td class="style4">
          联系方式</td>
      <td>
      <asp:TextBox ID="txtWebTel" CssClass="input" runat="server"></asp:TextBox>  

         </td>
      <td class="style2">
          传真号码</td>
      <td>
       <asp:TextBox ID="txtWebFax" CssClass="input" runat="server"></asp:TextBox>  
       
      
      </td>
    </tr>
    <tr>
      <td >电子邮件</td>
      <td>
       <asp:TextBox ID="txtWebEmail" CssClass="input" runat="server"></asp:TextBox>  
          
        </td>
      <td>网站备案号</td>
      <td>
       <asp:TextBox ID="txtWebCrod" CssClass="input" runat="server"></asp:TextBox>  

        </td>
    </tr>

    <tr>
      <td >服务器名称</td>
      <td>
         <%=Server.MachineName%>
        </td>
      <td>服务器IP</td>
      <td>
            <%=Request.ServerVariables["LOCAL_ADDR"]%>
        </td>
    </tr>


    <tr>
      <td >NET框架版本</td>
      <td>
          <%=Environment.Version.ToString()%>
        </td>
      <td>操作系统</td>
      <td>
             <%=Environment.OSVersion.ToString()%> 
        </td>
    </tr>

     <tr>
      <td >seesion总数</td>
      <td>
         <%=Session.Keys.Count.ToString() %>
        </td>
      <td>HTTPS支持</td>
      <td>
           <%=Request.ServerVariables["HTTPS"]%>
        </td>
    </tr>
    <tr>
      <td>
          版权信息</td>
      <td colspan="3">
         <asp:TextBox ID="txtWebCopyright" CssClass="input" runat="server"></asp:TextBox>  

        </td>
     
    </tr>
    <tr>
      <td>
          关键字</td>
      <td colspan="3">
    <asp:TextBox ID="txtWebKeywords" CssClass="input" runat="server"></asp:TextBox>  
      
        </td>
      
    </tr>
    <tr>
      <td>
          描述</td>
      <td colspan=3>
       <asp:TextBox ID="txtWebDescription" CssClass="input" runat="server"></asp:TextBox>  
      
        </td>
      
    </tr>
      </table>
     <div style="margin-top:10px; text-align:center;">
<asp:Button ID="btn" runat="server" Text="保存" CssClass="submit" onclick="btn_Click" />
     </div>
    
              
    </form>
</body>
</html>