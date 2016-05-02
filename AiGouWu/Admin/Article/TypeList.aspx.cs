using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AiGouWu.Admin.Article
{
    public partial class TypeList : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        string condition = " 1=1 ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newstypebind();
            }
        }

        /// <summary>
        /// 新闻类型绑定
        /// </summary>
        private void newstypebind()
        {
            this.gvList.DataSource = comm.getDataByCondition("tbNewsType", "TypeID,TypeName", condition);

            this.gvList.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            condition = "  TypeName like '%" + this.txtKeywords.Text + "%'";
            newstypebind();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvList.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gvList.Rows[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    Label lbid = (Label)gvList.Rows[i].FindControl("lbID");
                    comm.DeleteByCondition("tbNewsType", " where TypeID=" + lbid.Text);

                }
            }
            newstypebind();
        }


        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        


        }

        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvList.EditIndex = e.NewEditIndex;
            newstypebind();
        }

        protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id=this.gvList.DataKeys[e.RowIndex].Value.ToString();
            string typename=((TextBox)this.gvList.Rows[e.RowIndex].FindControl("txtName")).Text;
            comm.UpdateTableByCondition("tbNewsType", " TypeName='" + typename + "'", " where typeid=" + id);
            this.gvList.EditIndex = -1;
            newstypebind();
         
        }
        
    }
}
