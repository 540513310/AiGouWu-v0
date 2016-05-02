using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;

namespace AiGouWu.Admin.Manage
{
    public partial class list :System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        string condition = " 1=1 ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminList();

            }
        }

        private void AdminList()
        {
            this.rptList.DataSource = comm.getDataByCondition("tbAdmin", "*", condition);
            this.rptList.DataBind();
        }

     
        //批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    Label lbid = (Label)rptList.Items[i].FindControl("lb_id");
                    comm.UpdateTableByCondition(" tbAdmin ", " isdel=1 ", " where ID=" + lbid.Text);

                }
            }
            AdminList();
        }
    }
}
