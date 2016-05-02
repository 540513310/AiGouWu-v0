using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Orders
{
    /// <summary>
    /// tbOrdersPros:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbOrdersPros
    {
        public tbOrdersPros()
        { }
        #region Model
        private int _id;
        private int? _orderid;
        private int? _proid;
        private decimal? _discount;
        private decimal? _proprice;
        private int? _procount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProID
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ProPrice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProCount
        {
            set { _procount = value; }
            get { return _procount; }
        }
        #endregion Model

    }
}
