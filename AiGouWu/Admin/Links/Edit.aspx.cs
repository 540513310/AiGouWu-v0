using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Links;
namespace AiGouWu.Admin.Links
{
    public partial class Edit : System.Web.UI.Page
    {
        SqlComm comm = new SqlComm();
        tbLinksBLL linksbll = new tbLinksBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Length > 0)
                {
                    string id = Request.QueryString["id"].ToString();
                    tbLinks links=   linksbll.Links_getModel(id);
                    this.txtSiteName.Text = links.SiteName;
                    this.txtURL.Text = links.SiteUrl;
                    filename = links.SiteImg.ToString();
                    if (filename != "")
                    {
                        this.imgshow.ImageUrl = @"~\Admin\FileImg\Links\" + filename;
                        this.imgshow.Visible = true;
                    }
                    ddlShow.SelectedValue = links.isDel.ToString();
                    ddlShowimg.SelectedValue = links.isshowimg.ToString();

                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }

        }
        static string filename = "";
        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbLinks links = new tbLinks()
            {
                SiteId=int.Parse(Request.QueryString["id"].ToString()),
                SiteName = txtSiteName.Text.Trim(),
                SiteImg = filename,
                SiteUrl = txtURL.Text.Trim(),
                isshowimg = bool.Parse(ddlShowimg.SelectedValue.ToString()),
                isDel = bool.Parse(ddlShow.SelectedValue.ToString())

            };

           int count= linksbll.Links_Update(links);
           if (count != 0)
           {
               Response.Redirect("List.aspx");
           }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
          filename = fpImg.FileName;
          string path=Server.MapPath(@"\Admin\FileImg\Links\");
          fpImg.SaveAs(path + filename);
          this.imgshow.ImageUrl = @"~\Admin\FileImg\Links\" + filename;
          this.imgshow.Visible = true;
        }
    }
}