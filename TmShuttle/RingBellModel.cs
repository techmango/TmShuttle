using System;

namespace TmShuttle.Model
{
	/// <summary>
	/// RingBell:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RingBell
	{
        public RingBell()
        { }
        #region Model
        private int _id;
        private string _alias;
        private string _timekey;
        private int? _duaration;
        private string _filepath;
        private DateTime _ringtime;
        private string _filename;
        private int? _relayswitchon;
        private int? _relayswitchon2 = 0;
        private int? _relayswitchon3 = 0;
        private int? _relayswitchon4 = 0;
        private bool _enable = false;
        private DateTime? _createdate = DateTime.Now;
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
        public string Alias
        {
            set { _alias = value; }
            get { return _alias; }
        }
        /// <summary>
        /// 运行时间字符型（作为键）
        /// </summary>
        public string TimeKey
        {
            set { _timekey = value; }
            get { return _timekey; }
        }
        /// <summary>
        /// 时长（分钟）
        /// </summary>
        public int? Duaration
        {
            set { _duaration = value; }
            get { return _duaration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 实际运行时间运行时间
        /// </summary>
        public DateTime RingTime
        {
            set { _ringtime = value; }
            get { return _ringtime; }
        }
        /// <summary>
        /// 播放曲目文件名称
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 主机1的16个继电器开的逻辑与值
        /// </summary>
        public int? RelaySwitchOn
        {
            set { _relayswitchon = value; }
            get { return _relayswitchon; }
        }
        /// <summary>
        /// 主机2的16个继电器开的逻辑与值
        /// </summary>
        public int? RelaySwitchOn2
        {
            set { _relayswitchon2 = value; }
            get { return _relayswitchon2; }
        }
        /// <summary>
        /// 主机3的16个继电器开的逻辑与值
        /// </summary>
        public int? RelaySwitchOn3
        {
            set { _relayswitchon3 = value; }
            get { return _relayswitchon3; }
        }
        /// <summary>
        /// 主机4的16个继电器开的逻辑与值
        /// </summary>
        public int? RelaySwitchOn4
        {
            set { _relayswitchon4 = value; }
            get { return _relayswitchon4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

	}
}

