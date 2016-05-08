using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Model.Product;

namespace AiGouWu
{

    public partial class Product : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();

        public  static  DataTable dt;
        public static  DataTable imgsdt;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                this.re_renqi.DataSource = sqlcom.getDataByCondition("dbo.View_Product", "top 6 spec,product_name,smallimg,product_id,description", " type_id=9 order by product_id desc");
                this.re_renqi.DataBind();

            }


            if (Request.QueryString["proid"] != null)
            {
                //绑定产品的详细信息
                string proid = Request.QueryString["proid"].ToString();
                dt = sqlcom.getDataByCondition("View_detailPro", "*", "product_id=" + proid);
               
                //绑定产品的详细信息
                imgsdt = sqlcom.getDataByCondition("tbProimgs", "top 4 imgID,Proid,ImgName", " Proid='" + proid + "' order by imgID desc");
                if (imgsdt.Rows.Count > 0)
                {
                    this.proimgs.DataSource = imgsdt;
                    this.proimgs.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('此产品无效果图详细')", true);
                    return;
                }


                //绑定当前产品的评论
               DataTable leveldt= sqlcom.getDataByCondition("tbLevelwords", "*", " proid='" + Request.QueryString["proid"].ToString() + "' and isDel=0 and type='产品点评'");
               this.Re_LevelWords.DataSource = leveldt;
               this.Re_LevelWords.DataBind();

            }
            else
            {
                Response.Redirect("prolist.aspx");

            }

        }

        /// <summary>
        /// 提交客户评论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            tbLevelwords words = new tbLevelwords()
            {
                createdate = DateTime.Now,
                isDel = false,
                LevelWords = content.Value,
                UserName = txtusername.Text.ToString().Length == 0 ? "匿名用户" : txtusername.Text,
                proid = int.Parse(Request.QueryString["proid"].ToString()),
                type = "产品点评"
            };
            ProBLL pbll = new ProBLL();
            if (pbll.proLevelWords(words) != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('评论添加成功，需审核后显示')", true);
                return;
            
            }

        }
        //添加到购物车
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Cid"] == null)
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "tishi", "alert('请先登录后购买，谢谢')", true);

                this.lbTishi.Visible = true;
                return;
            }
            else
            {
                this.lbTishi.Visible = false;
            }
            
            TbCat cat = new TbCat()
            {
                Customerid = int.Parse(Session["Cid"].ToString()),
                DisCount = decimal.Parse(dt.Rows[0]["discount"].ToString()),
                Num = int.Parse(this.inputnum.Value.ToString()),
                ProID = int.Parse(Request.QueryString["proid"].ToString()),
                ProPrice = decimal.Parse(dt.Rows[0]["retail_price"].ToString()),
                IsOrders=false 

            };
            GoodsCatBLL gbll = new GoodsCatBLL();
            int catid= gbll.Add(cat);
            if (catid != 0)
            {
                Response.Redirect("ShoppingCart.aspx");
            }
            
        }
    }
}