using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
    /// <summary>
    /// tbProduct:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbProduct
    {
        public tbProduct()
        { }
        #region Model
        private int _product_id;
        private string _product_name;
        private int? _type_id;
        private decimal? _cost_price;
        private decimal? _wholesale_price;
        private decimal? _retail_price;
        private string _units;
        private string _weight;
        private string _material;
        private string _spec;
        private int? _upperlimit;
        private int? _lowerlimit;
        private DateTime? _expiry_date;
        private string _code;
        private string _description;
        private string _smallimg;
        private int _pingPaiId;
        private int _catalogid;
        private decimal? _discount;

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        private DateTime? _adddate;

        public DateTime? Adddate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }

        public int Catalogid
        {
            get { return _catalogid; }
            set { _catalogid = value; }
        }

        public int PingPaiId
        {
            get { return _pingPaiId; }
            set { _pingPaiId = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int product_id
        {
            set { _product_id = value; }
            get { return _product_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string product_name
        {
            set { _product_name = value; }
            get { return _product_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? type_id
        {
            set { _type_id = value; }
            get { return _type_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cost_price
        {
            set { _cost_price = value; }
            get { return _cost_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? wholesale_price
        {
            set { _wholesale_price = value; }
            get { return _wholesale_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? retail_price
        {
            set { _retail_price = value; }
            get { return _retail_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string units
        {
            set { _units = value; }
            get { return _units; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string material
        {
            set { _material = value; }
            get { return _material; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? upperLimit
        {
            set { _upperlimit = value; }
            get { return _upperlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lowerLimit
        {
            set { _lowerlimit = value; }
            get { return _lowerlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? expiry_date
        {
            set { _expiry_date = value; }
            get { return _expiry_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string smallimg
        {
            set { _smallimg = value; }
            get { return _smallimg; }
        }
        #endregion Model

    }
}
