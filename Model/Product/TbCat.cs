using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
    /// <summary>
    /// TbCat:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TbCat
    {
        public TbCat()
        { }
        #region Model
        private int _catid;
        private int? _customerid;
        private int? _proid;
        private int? _num;
        private decimal? _discount = 1M;
        private decimal? _proprice = 0M;
        /// <summary>
        /// 
        /// </summary>
        public int CatID
        {
            set { _catid = value; }
            get { return _catid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Customerid
        {
            set { _customerid = value; }
            get { return _customerid; }
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
        public int? Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DisCount
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
        #endregion Model

    }
}
