using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using JiDian.Model;

namespace JiDian.DAL {
	public partial class V2_PermissionsDAL {
		private DBExec dbExec = new DBExec();
		public V2_PermissionsDAL() {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_PermissionsDAL(SqlConnection connection) {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_PermissionsDAL(SqlConnection connection, SqlTransaction transaction) {
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
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Permissions ");
			strSQL.Append("WHERE id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithLogicKey(int page_id, string permission_key) {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Permissions ");
			strSQL.Append("WHERE page_id = @page_id AND permission_key = @permission_key");
			SqlParameter[] parameters = {
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = page_id;
			parameters[1].Value = permission_key;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithParam(string strWhere) {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Permissions ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			return dbExec.Exists(strSQL.ToString(), transaction);
		}

		public DataTable GetTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Permissions");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Permissions");
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT top " + topNum + " * FROM v2_Permissions");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Permissions");
		}

		public int GetCount(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT count(*) FROM v2_Permissions");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.ExecuteCountSql(strSQL.ToString(), transaction);
		}

		public DataTable ExecuteSql(string sql) {
			return dbExec.Query(sql.ToString(), transaction, "v2_Permissions");
		}

		public int ExecuteSqlCount(string sql) {
			return dbExec.ExecuteCountSql(sql, transaction);
		}

		public int AddRow(V2_PermissionsModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("INSERT INTO v2_Permissions(");
			strSQL.Append("page_id, permission_name, permission_key, offset)");
			strSQL.Append("VALUES(");
			strSQL.Append("@page_id, @permission_name, @permission_key, @offset);SELECT @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_name", SqlDbType.VarChar, 50),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50),
				new SqlParameter("@offset", SqlDbType.Int, 4)
				};
			parameters[0].Value = model.Page_id;
			parameters[1].Value = model.Permission_name;
			parameters[2].Value = model.Permission_key;
			parameters[3].Value = model.Offset;

			return dbExec.ExecuteAddSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRow(V2_PermissionsModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE v2_Permissions SET ");
			strSQL.Append("page_id = @page_id,");
			strSQL.Append("permission_name = @permission_name,");
			strSQL.Append("permission_key = @permission_key,");
			strSQL.Append("offset = @offset");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_name", SqlDbType.VarChar, 50),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50),
				new SqlParameter("@offset", SqlDbType.Int, 4)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Page_id;
			parameters[2].Value = model.Permission_name;
			parameters[3].Value = model.Permission_key;
			parameters[4].Value = model.Offset;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRowWithLogicKey(V2_PermissionsModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE v2_Permissions SET ");
			strSQL.Append("permission_name = @permission_name,");
			strSQL.Append("offset = @offset");
			strSQL.Append(" WHERE ");
			strSQL.Append("page_id = @page_id AND ");
			strSQL.Append("permission_key = @permission_key ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_name", SqlDbType.VarChar, 50),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50),
				new SqlParameter("@offset", SqlDbType.Int, 4)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Page_id;
			parameters[2].Value = model.Permission_name;
			parameters[3].Value = model.Permission_key;
			parameters[4].Value = model.Offset;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRow(V2_PermissionsModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Permissions");
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
			strSQL.Append("DELETE FROM v2_Permissions");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithLogicKey(int page_id, string permission_key) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Permissions");
			strSQL.Append(" WHERE ");
			strSQL.Append("page_id = @page_id AND ");
			strSQL.Append("permission_key = @permission_key");
			SqlParameter[] parameters = {
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = page_id;
			parameters[1].Value = permission_key;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithParam(string strWhere) {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Permissions ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			dbExec.ExecuteSql(strSQL.ToString(), transaction);
		}

		public DataRow GetSingleRow(int id) {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Permissions");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataRow GetSingleRowWithLogicKey(int page_id, string permission_key) {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Permissions");
			strSQL.Append(" WHERE ");
			strSQL.Append("page_id = @page_id AND ");
			strSQL.Append("permission_key = @permission_key");
			SqlParameter[] parameters = {
				new SqlParameter("@page_id", SqlDbType.Int, 4),
				new SqlParameter("@permission_key", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = page_id;
			parameters[1].Value = permission_key;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataTable GetVTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM vv2_Permissions");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "vv2_Permissions");
		}

		public DataRow GetLastRow() {
			V2_PermissionsModel model = new V2_PermissionsModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Permissions");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = ");
			strSQL.Append("(SELECT max(id) FROM v2_Permissions)");
			return dbExec.GetSingleRow(strSQL.ToString(), transaction);
		}

	}
}
