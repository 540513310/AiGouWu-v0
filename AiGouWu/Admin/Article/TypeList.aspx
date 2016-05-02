<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeList.aspx.cs" Inherits="AiGouWu.Admin.Article.TypeList"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>资讯管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link rel="stylesheet" type="text/css" href="../images/pagination.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script src="../Js/MyComm.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script src="../Js/TypeAdd.js" type="text/javascript"></script>
    <script type="text/javascript">
           
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
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div id="divTypeManger" style="width:250px; display:none; position:absolute;z-index: 200;background: #fff;">
     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">类型管理</th>
        </tr>
        <tr>
            <td width="25%" align="right">类型名称:</td>
            <td width="75%">
            <asp:TextBox ID="txtName" runat="server" CssClass="input" 
            maxlength="20" minlength="3" HintTitle="类型名称" HintInfo="控制在20个字数内，类型名称文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
         <td colspan="2"><div style="margin-top:10px;text-align:center;">

             <a onclick="TypeAdd()" id="btnaddtype" style="cursor:pointer">确 定</a>
                        <img style=" display:none;" id="loading" src="../Images/loading04.gif" alt="正在添加" title="正在添加..." />
                        <br />
                        <span id="showMes"></span>
      
         </div> </td>
        </tr>
      
        </table>
         
    </div>



    <div class="navigation"><span class="add"><a id="newtype">新增加类型</a></span><b>您当前的位置：首页 &gt; 资讯管理 &gt; 资讯类别列表</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">&nbsp;</td>
        <td>
           
        </td>
        <td width="50" align="right">关健字：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" 
                CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
    <div class="spClear"></div>


    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" 
        Width="100%" class="msgtable" DataKeyNames="TypeId" onrowcommand="gvList_RowCommand" 
        onrowediting="gvList_RowEditing" onrowupdating="gvList_RowUpdating">
    <Columns>
      <asp:TemplateField HeaderText="选择">    
    <ItemTemplate >
   <asp:CheckBox ID="cb_id" CssClass="checkall"  runat="server" />
    </ItemTemplate>
     <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="编号">    
    <ItemTemplate>
    <asp:Label ID="lbID" runat="server" Text='<%#Eval("TypeId") %>'></asp:Label>
    </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>

     <asp:TemplateField HeaderText="类型名称">    
    <ItemTemplate>
    <asp:Label ID="lbTypeName" runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtName" Text='<%#Eval("TypeName") %>' runat="server"></asp:TextBox>
    </EditItemTemplate>
      <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>

      <asp:TemplateField HeaderText="操作">    
    <ItemTemplate>
        <asp:LinkButton ID="lbBtn" CommandName="edit" runat="server">修改</asp:LinkButton>
    </ItemTemplate>
    <EditItemTemplate>
       <asp:LinkButton ID="lbBtn" CommandName="Update"   runat="server">确定</asp:LinkButton>
    </EditItemTemplate>
      <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    </Columns>
    </asp:GridView>

    <div class="spClear"></div>
        <div style="line-height:30px;height:30px;">
            <div id="Pagination" class="right flickr"></div>
            <div>
                <span class="btn_all" onclick="checkAll(this);">全选</span>
                <span class="btn_bg">
                  <asp:LinkButton ID="lbtnDel" runat="server" 
                    OnClientClick="return confirm( '确定要删除这些记录吗？ ');" onclick="lbtnDel_Click">删 除</asp:LinkButton>
                </span>
            </div>
	</div>
    <p>
&nbsp;
    </p>
    </form>
    </body>
</html>
