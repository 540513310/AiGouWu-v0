using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
    /// <summary>
    /// proCatalog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class proCatalog
    {
        public proCatalog()
        { }
        #region Model
        private int _id;
        private string _catalogid;
        private string _catalogname;
        private int? _typid;
        private int? _parentid;
        private bool? _isshow = true;
        private bool? _islock = false;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string catalogid
        {
            set { _catalogid = value; }
            get { return _catalogid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string catalogname
        {
            set { _catalogname = value; }
            get { return _catalogname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? typid
        {
            set { _typid = value; }
            get { return _typid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? isShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? isLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        #endregion Model

    }
}
