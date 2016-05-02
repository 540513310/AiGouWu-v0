using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Orders
{
    /// <summary>
    /// tbOrders:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tbOrders
    {
        public tbOrders()
        { }
        #region Model
        private int _orderid;
        private string _orderno;
        private int? _customerid;
        private string _address;
        private decimal? _totalmoney;
        private decimal? _postmoney;
        private int? _logid;
        private string _lognumber;
        private string _auditinguser;
        private decimal? _salesincome;
        private int? _userid;
        private DateTime? _createdate;
        private string _remark;
        private string _senduser;
        //state,username,tel,mobile,stateName
        private int _state;
        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _username;
        /// <summary>
        /// 来自视图
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _tel;
        /// <summary>
        /// 来自视图
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        private string _mobile;
        /// <summary>
        /// 来自视图
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        private string _stateName;
        /// <summary>
        /// 来自视图
        /// </summary>
        public string StateName
        {
            get { return _stateName; }
            set { _stateName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
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
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? totalMoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Postmoney
        {
            set { _postmoney = value; }
            get { return _postmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Logid
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogNumber
        {
            set { _lognumber = value; }
            get { return _lognumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string auditinguser
        {
            set { _auditinguser = value; }
            get { return _auditinguser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? salesincome
        {
            set { _salesincome = value; }
            get { return _salesincome; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? userid
        {
            set { _userid = value; }
            get { return _userid; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sendUser
        {
            set { _senduser = value; }
            get { return _senduser; }
        }
        #endregion Model

    }
}
