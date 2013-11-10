using System;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace TmShuttle.DAL
{
    public partial class ClassesDAL
    {
        public ClassesDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("class_id", "Classes");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int class_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Classes");
            strSql.Append(" where class_id=@class_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_id", OleDbType.Integer,4)
			};
            parameters[0].Value = class_id;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TmShuttle.Model.Classes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Classes(");
            strSql.Append("class_name,grade,relay_id,sb_bhao,box_id)");
            strSql.Append(" values (");
            strSql.Append("@class_name,@grade,@relay_id,@sb_bhao,@box_id)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_name", OleDbType.VarChar,50),
					new OleDbParameter("@grade", OleDbType.VarChar,50),
					new OleDbParameter("@relay_id", OleDbType.VarChar,50),
					new OleDbParameter("@sb_bhao", OleDbType.VarChar,50),
					new OleDbParameter("@box_id", OleDbType.VarChar,50)};
            parameters[0].Value = model.class_name;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.relay_id;
            parameters[3].Value = model.sb_bhao;
            parameters[4].Value = model.box_id;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateByRelayId(string class_name, string relay_id, int box_id)
        {
            string box_id_string = "主机" + box_id.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Classes set ");
            strSql.Append("class_name=@class_name");
            strSql.Append(" where relay_id=@relay_id and box_id=@box_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_name", OleDbType.VarChar,50),
                    new OleDbParameter("@box_id", OleDbType.VarChar, 50),
					new OleDbParameter("@relay_id", OleDbType.VarChar,50)};

            parameters[0].Value = class_name;
            parameters[1].Value = relay_id;
            parameters[2].Value = box_id_string;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TmShuttle.Model.Classes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Classes set ");
            strSql.Append("class_name=@class_name,");
            strSql.Append("grade=@grade,");
            strSql.Append("relay_id=@relay_id,");
            strSql.Append("sb_bhao=@sb_bhao,");
            strSql.Append("box_id=@box_id");
            strSql.Append(" where class_id=@class_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_name", OleDbType.VarChar,50),
					new OleDbParameter("@grade", OleDbType.VarChar,50),
					new OleDbParameter("@relay_id", OleDbType.VarChar,50),
					new OleDbParameter("@sb_bhao", OleDbType.VarChar,50),
					new OleDbParameter("@box_id", OleDbType.VarChar,50),
					new OleDbParameter("@class_id", OleDbType.Integer,4)};
            parameters[0].Value = model.class_name;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.relay_id;
            parameters[3].Value = model.sb_bhao;
            parameters[4].Value = model.box_id;
            parameters[5].Value = model.class_id;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int class_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Classes ");
            strSql.Append(" where class_id=@class_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_id", OleDbType.Integer,4)
			};
            parameters[0].Value = class_id;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string class_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Classes ");
            strSql.Append(" where class_id in (" + class_idlist + ")  ");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TmShuttle.Model.Classes GetModel(int class_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select class_id,class_name,grade,relay_id,sb_bhao,box_id from Classes ");
            strSql.Append(" where class_id=@class_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@class_id", OleDbType.Integer,4)
			};
            parameters[0].Value = class_id;

            TmShuttle.Model.Classes model = new TmShuttle.Model.Classes();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TmShuttle.Model.Classes DataRowToModel(DataRow row)
        {
            TmShuttle.Model.Classes model = new TmShuttle.Model.Classes();
            if (row != null)
            {
                if (row["class_id"] != null && row["class_id"].ToString() != "")
                {
                    model.class_id = int.Parse(row["class_id"].ToString());
                }
                if (row["class_name"] != null)
                {
                    model.class_name = row["class_name"].ToString();
                }
                if (row["grade"] != null)
                {
                    model.grade = row["grade"].ToString();
                }
                if (row["relay_id"] != null)
                {
                    model.relay_id = row["relay_id"].ToString();
                }
                if (row["sb_bhao"] != null)
                {
                    model.sb_bhao = row["sb_bhao"].ToString();
                }
                if (row["box_id"] != null)
                {
                    model.box_id = row["box_id"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select class_id,class_name,grade,relay_id,sb_bhao,box_id ");
            strSql.Append(" FROM Classes ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Classes ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.class_id desc");
            }
            strSql.Append(")AS Row, T.*  from Classes T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            OleDbParameter[] parameters = {
                    new OleDbParameter("@tblName", OleDbType.VarChar, 255),
                    new OleDbParameter("@fldName", OleDbType.VarChar, 255),
                    new OleDbParameter("@PageSize", OleDbType.Integer),
                    new OleDbParameter("@PageIndex", OleDbType.Integer),
                    new OleDbParameter("@IsReCount", OleDbType.Boolean),
                    new OleDbParameter("@OrderType", OleDbType.Boolean),
                    new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
                    };
            parameters[0].Value = "Classes";
            parameters[1].Value = "class_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

