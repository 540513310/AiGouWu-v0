using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace AiGouWu.Web.Admin.Article
{
    public partial class Edit : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        NewBLL newbll = new NewBLL();
        tbNews news = new tbNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newstypebind();
                if (Request.QueryString["id"] == null || Request.QueryString["id"].ToString().Length == 0)
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    string id = Request.QueryString["id"].ToString();

                  DataTable dt=  comm.getDataByCondition("Veiw_News", " * ", " newsid=" + id);
                  if (dt.Rows.Count > 0)
                  {
                      news.NewsID = int.Parse(dt.Rows[0]["NewsID"].ToString());
                      news.NewsTitle = dt.Rows[0]["NewsTitle"].ToString();
                      news.ClickNum = int.Parse(dt.Rows[0]["ClickNum"].ToString());
                      news.ImgUrl = dt.Rows[0]["ImgUrl"].ToString();
                      news.IsDel = bool.Parse(dt.Rows[0]["IsDel"].ToString());
                      news.KeyWords = dt.Rows[0]["KeyWords"].ToString();
                      news.Metades = dt.Rows[0]["Metades"].ToString();
                      news.NewsContent = dt.Rows[0]["NewsContent"].ToString();
                      news.OldUrl = dt.Rows[0]["OldUrl"].ToString();
                      news.Review = dt.Rows[0]["Review"].ToString();
                      news.TypeID = int.Parse(dt.Rows[0]["TypeID"].ToString());
                      news.Author = dt.Rows[0]["Author"].ToString();

                      pagebind();
                  }
                    
                }



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
        /// 页面信息绑定
        /// 2012-5-6
        /// </summary>
        public void pagebind()
        {
            this.txtAuthor.Text = news.Author;
            this.txtClick.Text = news.ClickNum.ToString();
            txtDaodu.Text = news.Review;
            txtForm.Text = news.OldUrl;
            txtKeyword.Text = news.KeyWords;
            txtTitle.Text = news.NewsTitle;
            txtZhaiyao.Text = news.Metades;
            FCKeditor.Value = news.NewsContent;
            this.ddlClassId.SelectedValue = news.TypeID.ToString();
            
        
        }

   

    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            news.Author = this.txtAuthor.Text;
            news.ClickNum = int.Parse(this.txtClick.Text);
            news.Review = txtDaodu.Text;
            news.OldUrl = txtForm.Text;
            news.KeyWords = txtKeyword.Text;
            news.NewsTitle = txtTitle.Text;
            news.Metades = txtZhaiyao.Text;
            news.TypeID = int.Parse(this.ddlClassId.SelectedValue.ToString());
            news.NewsContent = FCKeditor.Value;
           string img="";
            if (fpImg.HasFile)
            {
                img = DateTime.Now.ToString("yyyyMMddhhmmss") + fpImg.FileName;
                news.ImgUrl = img;
            }

            
            //判断是否执行成功
            if (newbll.Update(news) != 0)
            {
                //上传图片
                string path = Server.MapPath(@"\Admin\FileImg\NewsImg\");
                if (MyComm.FileUpLoad(fpImg, path, img) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
                }
            }
        }

    }
}
