using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using JiDian.Model;

namespace JiDian.DAL {
	public partial class V2_RoleDAL {
		private DBExec dbExec = new DBExec();
		public V2_RoleDAL() {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_RoleDAL(SqlConnection connection) {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public V2_RoleDAL(SqlConnection connection, SqlTransaction transaction) {
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
			V2_RoleModel model = new V2_RoleModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Role ");
			strSQL.Append("WHERE id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}


		public bool ExistsWithParam(string strWhere) {
			V2_RoleModel model = new V2_RoleModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM v2_Role ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			return dbExec.Exists(strSQL.ToString(), transaction);
		}

		public DataTable GetTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Role");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Role");
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT top " + topNum + " * FROM v2_Role");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "v2_Role");
		}

		public int GetCount(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT count(*) FROM v2_Role");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.ExecuteCountSql(strSQL.ToString(), transaction);
		}

		public DataTable ExecuteSql(string sql) {
			return dbExec.Query(sql.ToString(), transaction, "v2_Role");
		}

		public int ExecuteSqlCount(string sql) {
			return dbExec.ExecuteCountSql(sql, transaction);
		}

		public int AddRow(V2_RoleModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("INSERT INTO v2_Role(");
			strSQL.Append("role_name, permission, remark)");
			strSQL.Append("VALUES(");
			strSQL.Append("@role_name, @permission, @remark);SELECT @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@role_name", SqlDbType.VarChar, 50),
				new SqlParameter("@permission", SqlDbType.Image, 4000),
				new SqlParameter("@remark", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = model.Role_name;
			parameters[1].Value = model.Permission;
			parameters[2].Value = model.Remark;

			return dbExec.ExecuteAddSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRow(V2_RoleModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE v2_Role SET ");
			strSQL.Append("role_name = @role_name,");
			strSQL.Append("permission = @permission,");
			strSQL.Append("remark = @remark");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@role_name", SqlDbType.VarChar, 50),
				new SqlParameter("@permission", SqlDbType.Image, 4000),
				new SqlParameter("@remark", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Role_name;
			parameters[2].Value = model.Permission;
			parameters[3].Value = model.Remark;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}


		public void DeleteRow(V2_RoleModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Role");
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
			strSQL.Append("DELETE FROM v2_Role");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}


		public void DeleteRowWithParam(string strWhere) {
			V2_RoleModel model = new V2_RoleModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM v2_Role ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			dbExec.ExecuteSql(strSQL.ToString(), transaction);
		}

		public DataRow GetSingleRow(int id) {
			V2_RoleModel model = new V2_RoleModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Role");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}


		public DataTable GetVTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM vv2_Role");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "vv2_Role");
		}

		public DataRow GetLastRow() {
			V2_RoleModel model = new V2_RoleModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM v2_Role");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = ");
			strSQL.Append("(SELECT max(id) FROM v2_Role)");
			return dbExec.GetSingleRow(strSQL.ToString(), transaction);
		}

	}
}
