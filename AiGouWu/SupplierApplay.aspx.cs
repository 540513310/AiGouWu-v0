using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model.Customer;


namespace AiGouWu
{
    public partial class SupplierApplay: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            tbCustomer tbc = new tbCustomer()
            {
                address = txtAddress.Text,
                c_name = txtCName.Text,
                email = txtEmail.Text,
                link_men = txtLink.Text,
                mobile = txtMobile.Text,
                password = "123456",
                PinPai = txtPingPai.Text,
                ProName = txtProduct.Text,
                remark = txtBZ.Text,
                tel = txtTel.Text,
                types = 2,
                username = txtCName.Text
            };

            CustomerBLL cbll = new CustomerBLL();
            int cid=  cbll.supplierAdd(tbc);
            if (cid > 0)
            {
                Response.Redirect("ThankReg.htm");
            }
            
        }

  
  
    }
}