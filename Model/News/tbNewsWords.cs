using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.News
{
    /// <summary>
    /// tbNewsWords:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbNewsWords
    {
        public tbNewsWords()
        { }
        #region Model
        private int _id;
        private int? _newsid;
        private string _username;
        private string _levelcontent;
        private DateTime? _createdate = DateTime.Now;
        private bool? _isshenhe = false;
        private bool? _isdel = false;
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
        public int? NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LevelContent
        {
            set { _levelcontent = value; }
            get { return _levelcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? isShenhe
        {
            set { _isshenhe = value; }
            get { return _isshenhe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        #endregion Model

    }
}
