using System;
namespace Model
{
    /// <summary>
    /// tbRose:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbRose
    {
        public tbRose()
        { }
        #region Model
        private int _id;
        private string _rosename;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Rosename
        {
            set { _rosename = value; }
            get { return _rosename; }
        }
        #endregion Model

    }
}

