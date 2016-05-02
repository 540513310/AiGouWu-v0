using System;
namespace Model
{
    /// <summary>
    /// tbNewsType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbNewsType
    {
        public tbNewsType()
        { }
        #region Model
        private int _typeid;
        private string _typename;
        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        #endregion Model

    }
}

