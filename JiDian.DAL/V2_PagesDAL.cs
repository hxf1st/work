using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using JiDian.Model;

namespace JiDian.DAL {
	public partial class V2_PagesDAL {
		private DBExec dbExec = new DBExec();
		public V2_PagesDAL() {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_PagesDAL(SqlConnection connection) {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_PagesDAL(SqlConnection connection, SqlTransaction transaction) {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		public SqlConnection Connection {
			get {
				return connection;
			}
			set {
				connection = value;
			}
		}
		public SqlTransaction Transaction {
			get {
				return transaction;
			}
			set {
				transaction = value;
			}
		}
		public bool Exists(int id) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Pages ");
			strSQL.Append("WHERE id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithLogicKey(string url) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Pages ");
			strSQL.Append("WHERE url = @url");
			SqlParameter[] parameters = {
				new SqlParameter("@url", SqlDbType.VarChar, 128)
				};
			parameters[0].Value = url;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithParam(string strWhere) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Pages ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			return dbExec.Exists(strSQL.ToString(), transaction);
		}

		public DataTable GetTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Pages");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Pages");
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT top " + topNum + " * FROM v2_Pages");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Pages");
		}

		public int GetCount(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT count(*) FROM v2_Pages");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.ExecuteCountSql(strSQL.ToString(), transaction);
		}

		public DataTable ExecuteSql(string sql) {
			return dbExec.Query(sql.ToString(), transaction, "v2_Pages");
		}

		public int ExecuteSqlCount(string sql) {
			return dbExec.ExecuteCountSql(sql, transaction);
		}

		public int AddRow(V2_PagesModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("INSERT INTO v2_Pages(");
			strSQL.Append("category_id, page_name, url, ordernum, isnav, remark)");
			strSQL.Append("VALUES(");
			strSQL.Append("@category_id, @page_name, @url, @ordernum, @isnav, @remark);SELECT @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@category_id", SqlDbType.Int, 4),
				new SqlParameter("@page_name", SqlDbType.VarChar, 50),
				new SqlParameter("@url", SqlDbType.VarChar, 128),
				new SqlParameter("@ordernum", SqlDbType.Int, 4),
				new SqlParameter("@isnav", SqlDbType.Int, 4),
				new SqlParameter("@remark", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = model.Category_id;
			parameters[1].Value = model.Page_name;
			parameters[2].Value = model.Url;
			parameters[3].Value = model.Ordernum;
			parameters[4].Value = model.Isnav;
			parameters[5].Value = model.Remark;

			return dbExec.ExecuteAddSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRow(V2_PagesModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE v2_Pages SET ");
			strSQL.Append("category_id = @category_id,");
			strSQL.Append("page_name = @page_name,");
			strSQL.Append("url = @url,");
			strSQL.Append("ordernum = @ordernum,");
			strSQL.Append("isnav = @isnav,");
			strSQL.Append("remark = @remark");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@category_id", SqlDbType.Int, 4),
				new SqlParameter("@page_name", SqlDbType.VarChar, 50),
				new SqlParameter("@url", SqlDbType.VarChar, 128),
				new SqlParameter("@ordernum", SqlDbType.Int, 4),
				new SqlParameter("@isnav", SqlDbType.Int, 4),
				new SqlParameter("@remark", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Category_id;
			parameters[2].Value = model.Page_name;
			parameters[3].Value = model.Url;
			parameters[4].Value = model.Ordernum;
			parameters[5].Value = model.Isnav;
			parameters[6].Value = model.Remark;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRowWithLogicKey(V2_PagesModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE v2_Pages SET ");
			strSQL.Append("category_id = @category_id,");
			strSQL.Append("page_name = @page_name,");
			strSQL.Append("ordernum = @ordernum,");
			strSQL.Append("isnav = @isnav,");
			strSQL.Append("remark = @remark");
			strSQL.Append(" WHERE ");
			strSQL.Append("url = @url ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@category_id", SqlDbType.Int, 4),
				new SqlParameter("@page_name", SqlDbType.VarChar, 50),
				new SqlParameter("@url", SqlDbType.VarChar, 128),
				new SqlParameter("@ordernum", SqlDbType.Int, 4),
				new SqlParameter("@isnav", SqlDbType.Int, 4),
				new SqlParameter("@remark", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Category_id;
			parameters[2].Value = model.Page_name;
			parameters[3].Value = model.Url;
			parameters[4].Value = model.Ordernum;
			parameters[5].Value = model.Isnav;
			parameters[6].Value = model.Remark;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRow(V2_PagesModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = model.Id;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRow(int id) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithLogicKey(string url) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("url = @url");
			SqlParameter[] parameters = {
				new SqlParameter("@url", SqlDbType.VarChar, 128)
				};
			parameters[0].Value = url;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithParam(string strWhere) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Pages ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			dbExec.ExecuteSql(strSQL.ToString(), transaction);
		}

		public DataRow GetSingleRow(int id) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataRow GetSingleRowWithLogicKey(string url) {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("url = @url");
			SqlParameter[] parameters = {
				new SqlParameter("@url", SqlDbType.VarChar, 128)
				};
			parameters[0].Value = url;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataTable GetVTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM vv2_Pages");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "vv2_Pages");
		}

		public DataRow GetLastRow() {
			V2_PagesModel model = new V2_PagesModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Pages");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = ");
			strSQL.Append("(SELECT max(id) FROM v2_Pages)");
			return dbExec.GetSingleRow(strSQL.ToString(), transaction);
		}

	}
}
