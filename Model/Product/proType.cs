using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
    /// <summary>
    /// proType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class proType
    {
        public proType()
        { }
        #region Model
        private int _id;
        private string _typename;
        private int? _parentid;
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
        public string typeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
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
