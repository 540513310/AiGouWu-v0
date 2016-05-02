using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Customer
{
    /// <summary>
    /// tbCType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbCType
    {
        public tbCType()
        { }
        #region Model
        private int _id;
        private string _typename;
        private bool? _islock;
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
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
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
