using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
namespace AiGouWu.Admin.Article
{
    public partial class Add : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        NewBLL newbll = new NewBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              this.ddlClassId.DataSource= comm.getDataByCondition("tbNewsType", "TypeID,TypeName", null);
              this.ddlClassId.DataTextField = "TypeName";
              this.ddlClassId.DataValueField = "TypeID";
              this.ddlClassId.DataBind();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string img =DateTime.Now.ToString("yyyyMMddhhmmss")+fpImg.FileName;
            tbNews news = new tbNews()
            {
                Author = this.txtAuthor.Text,
                ClickNum = int.Parse(this.txtClick.Text),
                KeyWords = this.txtKeyword.Text,
                Metades = this.txtZhaiyao.Text,
                OldUrl = this.txtForm.Text,
                NewsContent = this.FCKeditor1.Value,
                NewsTitle = this.txtTitle.Text,
                Review = this.txtDaodu.Text,
                TypeID = int.Parse(this.ddlClassId.SelectedValue),
                ImgUrl = img
            };


          int count=  newbll.Add(news);
          if (count != 0)
          {
              //上传图片
              string path=Server.MapPath(@"\Admin\FileImg\NewsImg\");
              if (MyComm.FileUpLoad(fpImg, path, img) == "false")
              {
                  ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
              }
              
          }

        }

        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}