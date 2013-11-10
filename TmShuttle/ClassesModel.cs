using System;
namespace TmShuttle.Model
{
	/// <summary>
	/// Classes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Classes
	{
        public Classes()
        { }
        #region Model
        private int _class_id;
        private string _class_name;
        private string _grade;
        private string _relay_id = "0";
        private string _sb_bhao = "1";
        private string _box_id;
        /// <summary>
        /// 
        /// </summary>
        public int class_id
        {
            set { _class_id = value; }
            get { return _class_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string class_name
        {
            set { _class_name = value; }
            get { return _class_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string relay_id
        {
            set { _relay_id = value; }
            get { return _relay_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sb_bhao
        {
            set { _sb_bhao = value; }
            get { return _sb_bhao; }
        }
        /// <summary>
        /// 主机编号
        /// </summary>
        public string box_id
        {
            set { _box_id = value; }
            get { return _box_id; }
        }
        #endregion Model

	}
}

