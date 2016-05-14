using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Products
{
    public partial class proList : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();

        string condition = "  ";
        //每页5条
        int pagesize = 5;
        //总共条数
        int recordCount = 0;
        //第几页
        int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               this.ddlClassId.DataSource= comm.getDataByCondition("proType", "id,typename", " 1=1");
               this.ddlClassId.DataTextField = "typename";
               this.ddlClassId.DataValueField = "id";
               this.ddlClassId.DataBind();

                getprosList();
                AspNetPager1.RecordCount = recordCount;
                AspNetPager1.PageSize = pagesize;
            
            }
        }
       


        /// <summary>
        /// 产品列表绑定
        /// </summary>
        private void getprosList()
        {
            rptList.DataSource = comm.getdatabyPageIndex("View_Product", "*", condition, pagesize, pageindex, "product_id", out recordCount,null,null);
            rptList.DataBind();
        }
              
       
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bdelete")
            {
                string id = e.CommandArgument.ToString();
                comm.DeleteByCondition("tbProduct", " where product_id=" + id);
                getprosList();
            }
            
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }


        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = " and product_name like '" + this.txtKeywords.Text + "%'";
            pageindex = 0;
            getprosList();

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
                comm.DeleteByCondition("tbProduct", " where product_id=" + lbid.Text);
                }
            }
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex=this.AspNetPager1.CurrentPageIndex - 1;
            getprosList();
        }

    }
}
