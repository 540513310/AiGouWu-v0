using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Article
{
    public partial class List :System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();

        string condition = " and isDel=0 ";
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
                newstypebind();
                getNewsList();
                AspNetPager1.RecordCount = recordCount;
                AspNetPager1.PageSize = pagesize;
            
            }
        }
        /// <summary>
        /// 新闻类型绑定
        /// </summary>
        private void newstypebind()
        {
            this.ddlClassId.DataSource = comm.getDataByCondition("tbNewsType", "TypeID,TypeName", null);
            this.ddlClassId.DataTextField = "TypeName";
            this.ddlClassId.DataValueField = "TypeID";
            this.ddlClassId.DataBind();
        }
        /// <summary>
        /// 新闻列表绑定
        /// </summary>
        private void getNewsList()
        {
            //2012-5-8
            //使用分页功能，定义输出参数返回 总条数
            rptList.DataSource = comm.getdatabyPageIndex("Veiw_News", "*", condition, pagesize, pageindex, "NewsID", out recordCount,null,null);
            rptList.DataBind();
        }
              
       
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
            
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = " and TypeID ="+ this.ddlClassId.SelectedValue.ToString();
            getNewsList();
        }


        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = " and  TypeID =" + this.ddlClassId.SelectedValue.ToString()+" and NewsTitle like '%"+this.txtKeywords.Text+"%'";
            getNewsList();
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
                //comm.DeleteByCondition("tbNews", " where newsid=" + lbid.Text);
                comm.UpdateTableByCondition("tbNews", " IsDel=1 ", " where newsid=" + lbid.Text);

                }
            }
            getNewsList();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            pageindex=this.AspNetPager1.CurrentPageIndex - 1;
            getNewsList();

        }

    }
}
