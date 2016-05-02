using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Product;
namespace AiGouWu.Admin.Products
{
    public partial class Test : System.Web.UI.Page
    {
        public   tbProduct p;
        public string aa = "aa";
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.ProBLL pbll = new ProBLL();
            p = pbll.GetModel(1);


        }
    }
}