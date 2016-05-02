using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Customer
{
    public partial class CustomerList :System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();

        string condition = " and isLock=0  ";
        //每页5条
       static  int pagesize = 5;
        //总共条数
       static int recordCount = 0;
        //第几页
       static int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                customerlistbind();
                AspNetPager1.RecordCount = recordCount;
                AspNetPager1.PageSize = pagesize;
                this.ddlClassId.DataSource = comm.getDataByCondition("tbCType", "TypeName,id", " 1=1");
                this.ddlClassId.DataTextField = "TypeName";
                this.ddlClassId.DataValueField = "id";
                this.ddlClassId.DataBind();
            }
        }

        private void customerlistbind()
        {
            rptList.DataSource = comm.getdatabyPageIndex("view_Customer", "*", condition, pagesize, pageindex, "id", out recordCount,null,null);
            rptList.DataBind();
    

        }
       
     
              
       
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

           
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = " and isLock=0  and types=" + this.ddlClassId.SelectedValue.ToString();
        
            customerlistbind();  
            AspNetPager1.RecordCount = recordCount;
            AspNetPager1.PageSize = pagesize;
        }


        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = " and isLock=0 and username like '" + this.txtKeywords.Text + "%'";
            customerlistbind();
            AspNetPager1.RecordCount = recordCount;
            AspNetPager1.PageSize = pagesize;
        }
        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rptList.Items.Count; i++)
           {
             CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
              if (cb.Checked)
             {
               Label lbid= (Label)rptList.Items[i].FindControl("lbID");
               comm.UpdateTableByCondition("tbCustomer", " state=1 ", " where id=" + lbid.Text);
               
             }
            }
            customerlistbind();
         
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex=this.AspNetPager1.CurrentPageIndex - 1;
            customerlistbind();
        }

    }
}
