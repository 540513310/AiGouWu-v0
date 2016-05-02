using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
namespace AiGouWu
{
    public partial class prolist : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        static int pagesize = 5;
        static int pageindex = 0;
        static string condition = "";
        static int totalcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            

          
        //  Response.Write("<script>alert('" + Server.UrlDecode(Name) + "')</script>");

            if (!IsPostBack)
            {
             
                xuanxiangkabind();
                renqipaihang();
                catlist();
                DataTable dt=new DataTable();
                if (Request.QueryString["cateid"] != null)
                {
                    string cateid = Request.QueryString["cateid"].ToString();
                    condition = " and catalogid=" + cateid;
                    dt = sqlcom.getdatabyPageIndex("dbo.View_Product", " Product_id,product_name,smallimg,description,retail_price,discount", condition, pagesize, pageindex, "product_id", out  totalcount,null,null);
                 
                }
                else
                {

                    dt = sqlcom.getdatabyPageIndex("dbo.View_Product", " Product_id,product_name,smallimg,description,retail_price,discount", condition, pagesize, pageindex, "product_id", out  totalcount,null,null);
                 
                }

                if (Request.QueryString["typeid"] != null)
                {
                    string typeid = Request.QueryString["typeid"].ToString();
                    condition = " and type_id=" + typeid;
                    dt = sqlcom.getdatabyPageIndex("dbo.View_Product", " Product_id,product_name,smallimg,description,retail_price,discount", condition, pagesize, pageindex, "product_id", out  totalcount, null, null);
                 
                }




                this.AspNetPager1.RecordCount = totalcount;
                this.AspNetPager1.PageSize = pagesize;
                this.proslist.DataSource = dt;
                this.proslist.DataBind();  
              
            }

            //根据产品名称进行搜索
            if (Request.QueryString["proname"] != null)
            {
                string Name = Request.QueryString["proname"];


                if (Request.QueryString["cateid"] != null)
                {
                    condition = " and catalogid=" + Request.QueryString["cateid"].ToString() + " and product_name like '%" + Name + "%'";
                }
                else
                {
                    condition = " and product_name like '%" + Name + "%'";
                }

                pageindex = 0;
                prolistbind("product_id", "desc");
            }


        }

       
        /// <summary>
        /// 重新绑定产品列表信息
        /// </summary>
        /// <param name="ordercolumns"></param>
        /// <param name="isasc"></param>
        public void prolistbind(string ordercolumns,string isasc)
        {
           
            this.proslist.DataSource = sqlcom.getdatabyPageIndex("dbo.View_Product", " Product_id,product_name,smallimg,description,retail_price,discount", condition, pagesize, pageindex, "product_id", out  totalcount, ordercolumns, isasc);
            this.proslist.DataBind();
            this.AspNetPager1.RecordCount = totalcount;
            this.AspNetPager1.PageSize = pagesize;
        }



   
         public  DataTable dt;
        /// <summary>
        /// 获取展示窗口相关数据（轮换广告）
        /// </summary>
        public void lunxunguanggao()
        {
          dt=sqlcom.getDataByCondition("dbo.View_Product", "top 6 Product_id,product_name,smallimg ", " type_id=7 order by Product_id desc");
                   
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
           this.re_renqi.DataSource= sqlcom.getDataByCondition("tbProduct", "tbProduct.product_name,tbProduct.product_id", "product_id IN(SELECT TOP 10 proid FROM tbOrdersPros GROUP BY ProID ORDER BY sum(Procount) DESC)");
           this.re_renqi.DataBind();
        }
                
        /// <summary>
        /// 类别列表
        /// </summary>
        public void catlist()
        {
            this.datalist_catlist.DataSource = sqlcom.getDataByCondition("proCatalog", "id,typid,catalogname,Parentid", " Parentid=0");
            this.datalist_catlist.DataBind();
        }
        public DataTable dt_catalog;   
        protected void datalist_catlist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater recatitem = e.Item.FindControl("catitem") as Repeater;
                DataRowView rowview = (DataRowView)e.Item.DataItem;
                string pid = rowview["id"].ToString();
                dt_catalog = sqlcom.getDataByCondition("proCatalog", "id,typid,catalogname,Parentid", "Parentid=" + pid);
                recatitem.DataSource = dt_catalog;
                recatitem.DataBind();
            }
        }

        //根据价格排序
        protected void ddlPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["cateid"] != null)
            {
                condition = " and catalogid=" + Request.QueryString["cateid"].ToString();
            }
            if (this.ddlPriceList.SelectedValue.ToString() == "0")
            {
                prolistbind("retail_price", "asc");
            }
            else
            {
                prolistbind("retail_price", "desc");
            }
     
        }

        /// <summary>
        /// 根据发布日期排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["cateid"] != null)
            {
                condition = " and catalogid=" + Request.QueryString["cateid"].ToString();
            }

            if (ddlDate.SelectedValue.ToString() == "0")
            {
                prolistbind("addDate", "desc");
            }
            else
            {
                prolistbind("addDate", "asc");
            }

         
        }

        /// <summary>
        /// 关键字搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cateid"] != null)
            {
                condition = " and catalogid=" + Request.QueryString["cateid"].ToString() + " and product_name like '%" + this.keywords.Text + "%'";
            }
            else
            {
                condition = " and product_name like '%" + this.keywords.Text + "%'";
            }

            prolistbind("product_id","desc");
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
           pageindex=  this.AspNetPager1.CurrentPageIndex - 1;
           prolistbind("product_id", "desc");
        }

       

    }
}