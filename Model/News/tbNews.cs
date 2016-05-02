using System;
namespace Model
{
	/// <summary>
	/// tbNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbNews
	{
		public tbNews()
		{}
		#region Model
		private int _newsid;
		private string _newstitle;
		private string _newscontent;
		private int? _typeid;
		private string _oldurl;
		private string _author;
		private string _keywords;
		private string _metades;
		private string _review;
		private int? _clicknum=0;
		private bool? _isdel= false;
		private DateTime? _createdate= DateTime.Now;
        private string _imgUrl;

        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OldUrl
		{
			set{ _oldurl=value;}
			get{return _oldurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Metades
		{
			set{ _metades=value;}
			get{return _metades;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Review
		{
			set{ _review=value;}
			get{return _review;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClickNum
		{
			set{ _clicknum=value;}
			get{return _clicknum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

