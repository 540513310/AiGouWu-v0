using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Product
{
  public   class tbLevelwords
    {
        public tbLevelwords()
        { }
        #region Model
        private int _id;
        private int? _proid;
        private string _username;
        private string _levelwords;
        private string _type;
        private DateTime? _createdate = DateTime.Now;
        private bool? _isdel = false;
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
        public int? proid
        {
            set { _proid = value; }
            get { return _proid; }
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
        public string LevelWords
        {
            set { _levelwords = value; }
            get { return _levelwords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
