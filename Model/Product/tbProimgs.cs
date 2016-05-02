using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
    /// <summary>
    /// tbProimgs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbProimgs
    {
        public tbProimgs()
        { }
        #region Model
        private int _imgid;
        private int? _proid;
        private string _imgname;
        private string _product_name;

        public string Product_name
        {
            get { return _product_name; }
            set { _product_name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int imgID
        {
            set { _imgid = value; }
            get { return _imgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Proid
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgName
        {
            set { _imgname = value; }
            get { return _imgname; }
        }
        #endregion Model

    }
}
