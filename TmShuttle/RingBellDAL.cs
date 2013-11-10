using System;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace TmShuttle.DAL
{
	/// <summary>
	/// 数据访问类:RingBell
	/// </summary>
	public partial class RingBellDAL
	{
        public RingBellDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("ID", "RingBell"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RingBell");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TmShuttle.Model.RingBell model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RingBell(");
			strSql.Append("Alias,TimeKey,Duaration,FilePath,RingTime,FileName,RelaySwitchOn,RelaySwitchOn2,RelaySwitchOn3,RelaySwitchOn4,Enable,CreateDate)");
			strSql.Append(" values (");
			strSql.Append("@Alias,@TimeKey,@Duaration,@FilePath,@RingTime,@FileName,@RelaySwitchOn,@RelaySwitchOn2,@RelaySwitchOn3,@RelaySwitchOn4,@Enable,@CreateDate)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Alias", OleDbType.VarChar,255),
					new OleDbParameter("@TimeKey", OleDbType.VarChar,100),
					new OleDbParameter("@Duaration", OleDbType.Integer,4),
					new OleDbParameter("@FilePath", OleDbType.VarChar,255),
					new OleDbParameter("@RingTime", OleDbType.Date),
					new OleDbParameter("@FileName", OleDbType.VarChar,100),
					new OleDbParameter("@RelaySwitchOn", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn2", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn3", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn4", OleDbType.Integer,4),
					new OleDbParameter("@Enable", OleDbType.Boolean,1),
					new OleDbParameter("@CreateDate", OleDbType.Date)};
			parameters[0].Value = model.Alias;
			parameters[1].Value = model.TimeKey;
			parameters[2].Value = model.Duaration;
			parameters[3].Value = model.FilePath;
			parameters[4].Value = model.RingTime;
			parameters[5].Value = model.FileName;
			parameters[6].Value = model.RelaySwitchOn;
			parameters[7].Value = model.RelaySwitchOn2;
			parameters[8].Value = model.RelaySwitchOn3;
			parameters[9].Value = model.RelaySwitchOn4;
			parameters[10].Value = model.Enable;
			parameters[11].Value = model.CreateDate;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(TmShuttle.Model.RingBell model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RingBell set ");
			strSql.Append("Alias=@Alias,");
			strSql.Append("TimeKey=@TimeKey,");
			strSql.Append("Duaration=@Duaration,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("RingTime=@RingTime,");
			strSql.Append("FileName=@FileName,");
			strSql.Append("RelaySwitchOn=@RelaySwitchOn,");
			strSql.Append("RelaySwitchOn2=@RelaySwitchOn2,");
			strSql.Append("RelaySwitchOn3=@RelaySwitchOn3,");
			strSql.Append("RelaySwitchOn4=@RelaySwitchOn4,");
			strSql.Append("Enable=@Enable,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Alias", OleDbType.VarChar,255),
					new OleDbParameter("@TimeKey", OleDbType.VarChar,100),
					new OleDbParameter("@Duaration", OleDbType.Integer,4),
					new OleDbParameter("@FilePath", OleDbType.VarChar,255),
					new OleDbParameter("@RingTime", OleDbType.Date),
					new OleDbParameter("@FileName", OleDbType.VarChar,100),
					new OleDbParameter("@RelaySwitchOn", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn2", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn3", OleDbType.Integer,4),
					new OleDbParameter("@RelaySwitchOn4", OleDbType.Integer,4),
					new OleDbParameter("@Enable", OleDbType.Boolean,1),
					new OleDbParameter("@CreateDate", OleDbType.Date),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.Alias;
			parameters[1].Value = model.TimeKey;
			parameters[2].Value = model.Duaration;
			parameters[3].Value = model.FilePath;
			parameters[4].Value = model.RingTime;
			parameters[5].Value = model.FileName;
			parameters[6].Value = model.RelaySwitchOn;
			parameters[7].Value = model.RelaySwitchOn2;
			parameters[8].Value = model.RelaySwitchOn3;
			parameters[9].Value = model.RelaySwitchOn4;
			parameters[10].Value = model.Enable;
			parameters[11].Value = model.CreateDate;
			parameters[12].Value = model.ID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RingBell ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RingBell ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelper.ExecuteSql(strSql.ToString());
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
		public TmShuttle.Model.RingBell GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Alias,TimeKey,Duaration,FilePath,RingTime,FileName,RelaySwitchOn,RelaySwitchOn2,RelaySwitchOn3,RelaySwitchOn4,Enable,CreateDate from RingBell ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			TmShuttle.Model.RingBell model=new TmShuttle.Model.RingBell();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public TmShuttle.Model.RingBell DataRowToModel(DataRow row)
		{
			TmShuttle.Model.RingBell model=new TmShuttle.Model.RingBell();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Alias"]!=null)
				{
					model.Alias=row["Alias"].ToString();
				}
				if(row["TimeKey"]!=null)
				{
					model.TimeKey=row["TimeKey"].ToString();
				}
				if(row["Duaration"]!=null && row["Duaration"].ToString()!="")
				{
					model.Duaration=int.Parse(row["Duaration"].ToString());
				}
				if(row["FilePath"]!=null)
				{
					model.FilePath=row["FilePath"].ToString();
				}
				if(row["RingTime"]!=null && row["RingTime"].ToString()!="")
				{
					model.RingTime=DateTime.Parse(row["RingTime"].ToString());
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["RelaySwitchOn"]!=null && row["RelaySwitchOn"].ToString()!="")
				{
					model.RelaySwitchOn=int.Parse(row["RelaySwitchOn"].ToString());
				}
				if(row["RelaySwitchOn2"]!=null && row["RelaySwitchOn2"].ToString()!="")
				{
					model.RelaySwitchOn2=int.Parse(row["RelaySwitchOn2"].ToString());
				}
				if(row["RelaySwitchOn3"]!=null && row["RelaySwitchOn3"].ToString()!="")
				{
					model.RelaySwitchOn3=int.Parse(row["RelaySwitchOn3"].ToString());
				}
				if(row["RelaySwitchOn4"]!=null && row["RelaySwitchOn4"].ToString()!="")
				{
					model.RelaySwitchOn4=int.Parse(row["RelaySwitchOn4"].ToString());
				}
				if(row["Enable"]!=null && row["Enable"].ToString()!="")
				{
					if((row["Enable"].ToString()=="1")||(row["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
					}
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Alias,TimeKey,Duaration,FilePath,RingTime,FileName,RelaySwitchOn,RelaySwitchOn2,RelaySwitchOn3,RelaySwitchOn4,Enable,CreateDate ");
			strSql.Append(" FROM RingBell ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM RingBell ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from RingBell T ");
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
			parameters[0].Value = "RingBell";
			parameters[1].Value = "ID";
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

