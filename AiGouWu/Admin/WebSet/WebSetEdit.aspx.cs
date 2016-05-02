using System;
using System.Data;
using System.Web;
using BLL;
using Model.WebSet;


namespace AiGouWu.Admin.WebSet
{
    public partial class WebSetEdit: System.Web.UI.Page
    {


        WebSetBLL wsbll = new WebSetBLL();       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                tbWebSet webset = new tbWebSet();
                webset = wsbll.GetModel(1);
                txtWebName.Text = webset.WebName;
                txtWebUrl.Text = webset.WebUrl;
                txtWebTel.Text = webset.WebTel;
                txtWebCrod.Text = webset.WebCrod;
                txtWebDescription.Text = webset.WebDescription;
                txtWebKeywords.Text = webset.WebKeywords;
                txtWebFax.Text = webset.WebFax;
                txtWebEmail.Text = webset.WebEmail;
                txtWebCopyright.Text = webset.WebCopyright;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            tbWebSet w = new tbWebSet()
            {
                ID = 1,
                WebCopyright = txtWebCopyright.Text,
                WebCrod = txtWebCrod.Text,
                WebDescription = txtWebDescription.Text,
                WebEmail = txtWebEmail.Text,
                WebFax = txtWebFax.Text,
                WebKeywords = txtWebKeywords.Text,
                WebName = txtWebName.Text,
                WebTel = txtWebTel.Text,
                WebUrl = txtWebUrl.Text
            };
            if (wsbll.Update(w) != 0)
            {
                Response.Redirect("WebSetDetail.aspx");
            }
        }
      

    }
}
