using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
namespace AiGouWu
{
    public partial class NewsDetail : System.Web.UI.Page
    {
      public   static System.Data.DataTable dt;
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["newsid"] != null && Request["newsid"].ToString().Length > 0)
            {

                xuanxiangkabind();
                renqipaihang();
                NewsLevelList();

                string newsid = Request["newsid"].ToString();

                dt = sqlcom.getDataByCondition("dbo.Veiw_News", "*", " NewsID=" + newsid);
                if (dt == null)
                {
                    Response.Redirect("NewsList.aspx");
                }


            }
            else
            {
                Response.Redirect("NewsList.aspx");
            }
        }


        /// <summary>
        /// 选项卡绑定
        /// </summary>
        public void xuanxiangkabind()
        {
            this.retuijian.DataSource = sqlcom.getDataByCondition("ProimgsbyTypeid_view", "Product_id,product_name,smallimg,type_id", " type_id=9");
            this.retuijian.DataBind();
        }

        /// <summary>
        /// 人气排行，统计销售数量前10的产品信息
        /// </summary>
        public void renqipaihang()
        {
            this.re_renqi.DataSource = sqlcom.getDataByCondition("tbProduct", "tbProduct.product_name,tbProduct.product_id", "product_id IN(SELECT TOP 10 proid FROM tbOrdersPros GROUP BY ProID ORDER BY sum(Procount) DESC)");
            this.re_renqi.DataBind();
        }

        //绑定留言列表
        public void NewsLevelList()
        {
            this.Re_LevelWords.DataSource = sqlcom.getDataByCondition("dbo.NewsWords_View", "*", " NewsID=" + Request["newsid"].ToString());
          this.Re_LevelWords.DataBind();
        
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Model.News.tbNewsWords w = new Model.News.tbNewsWords()
            {
                NewsID = int.Parse(Request["newsid"].ToString()),
                UserName = txtusername.Text.ToString().Length == 0 ? "匿名用户" : txtusername.Text,
                LevelContent = content.Value.ToString().Trim().Replace("王八蛋", "")
               
                
            };
            BLL.NewBLL nbll = new NewBLL();
           int count= nbll.NewsWordsAdd(w);
           if (count != 0)
           { 
           //ScriptManager.RegisterStartupScript
               NewsLevelList();
               lbShow.Visible = true;
               this.txtusername.Text = "";
               this.content.Value = "";
           }

        }
    }
}