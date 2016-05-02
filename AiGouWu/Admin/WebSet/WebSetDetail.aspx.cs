using System;
using System.Data;
using System.Web;
using BLL;
using Model.WebSet;


namespace AiGouWu.Admin.WebSet
{
    public partial class WebSetDetail : System.Web.UI.Page
    {


        WebSetBLL wsbll = new WebSetBLL();
        public static tbWebSet webset = new tbWebSet();
        protected void Page_Load(object sender, EventArgs e)
        {
          webset=  wsbll.GetModel(1);
         
        }
      

    }
}
