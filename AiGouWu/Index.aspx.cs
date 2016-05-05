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
    public partial class Index : System.Web.UI.Page
    {
        SqlComm sqlcom = new SqlComm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                getteijiashangping("8");
                getzuixinpro();
                lunxunguanggao();
                xuanxiangkabind();
                renqipaihang();
                catlist();
                newslist();
            }

        }
        /// <summary>
        /// 特价商品
        /// </summary>
        /// <param name="typeid"></param>
        public void getteijiashangping(string typeid)
        { 
        DataTable dt=    sqlcom.getDataByCondition("dbo.View_Product"," top 3 Product_id,product_name,smallimg "," type_id="+typeid+"  order by Product_id desc");
        this.re_teijia.DataSource = dt;
        this.re_teijia.DataBind();
        
        }

        /// <summary>
        /// 绑定最新上市的商品
        /// </summary>
        public void getzuixinpro()
        {
            DataTable dt = sqlcom.getDataByCondition("dbo.View_Product", " top 6 Product_id,product_name,smallimg ", "  1=1   order by Product_id desc");
            this.zuixinpro.DataSource = dt;
            this.zuixinpro.DataBind();
        }

         public  DataTable dt;
        /// <summary>
        /// 获取展示窗口相关数据（轮换广告）
        /// </summary>
        public void lunxunguanggao()
        {
          dt=sqlcom.getDataByCondition("dbo.View_Product", "top 6 Product_id,product_name,smallimg ", " type_id=7 order by Product_id desc");
                   
        }

        public DataTable tb_dt;
        /// <summary>
        /// 选项卡绑定
        /// </summary>
        public void xuanxiangkabind()
        {
            tb_dt = sqlcom.getDataByCondition("ProimgsbyTypeid_view", "Product_id,product_name,smallimg,type_id", " 1=1");
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
            //Time：2012-6-11
            //author:tiger
            //desc:增加代码：e.Item.ItemType==ListItemType.AlternatingItem 奇偶交替绑定
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

       
        /// <summary>
        /// 公告信息绑定
        /// </summary>
        public void newslist()
        {
          //re_gonggao.DataSource=  sqlcom.getDataByCondition("tbNews", " top 3 NewsID,NewsTitle", " TypeID=14 order by NewsID desc");
          //this.re_gonggao.DataBind();

          //hangyenews.DataSource = sqlcom.getDataByCondition("tbNews", " top 8 NewsID,NewsTitle", " TypeID=1 order by NewsID desc");
          //hangyenews.DataBind();

          //this.gongsiNews.DataSource = sqlcom.getDataByCondition("tbNews", " top 8 NewsID,NewsTitle", " TypeID=2 order by NewsID desc");
          //gongsiNews.DataBind();

          //this.guoneiNews.DataSource = sqlcom.getDataByCondition("tbNews", " top 8 NewsID,NewsTitle", " TypeID=13 order by NewsID desc");
          //guoneiNews.DataBind();

        }
    }
}