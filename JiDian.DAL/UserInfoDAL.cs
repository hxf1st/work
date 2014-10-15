using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using JiDian.Model;

namespace JiDian.DAL {
	public partial class UserInfoDAL {
		private DBExec dbExec = new DBExec();
		public UserInfoDAL() {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public UserInfoDAL(SqlConnection connection) {
			dbExec.Connection = connection;
			dbExec.Transaction = transaction;
		}
		public UserInfoDAL(SqlConnection connection, SqlTransaction transaction) {
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
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM UserInfo ");
			strSQL.Append("WHERE id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithLogicKey(string account) {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM UserInfo ");
			strSQL.Append("WHERE account = @account");
			SqlParameter[] parameters = {
				new SqlParameter("@account", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = account;

			return dbExec.Exists(strSQL.ToString(), transaction, parameters);
		}

		public bool ExistsWithParam(string strWhere) {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT COUNT(1) FROM UserInfo ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			return dbExec.Exists(strSQL.ToString(), transaction);
		}

		public DataTable GetTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM UserInfo");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "UserInfo");
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT top " + topNum + " * FROM UserInfo");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "UserInfo");
		}

		public int GetCount(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT count(*) FROM UserInfo");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.ExecuteCountSql(strSQL.ToString(), transaction);
		}

		public DataSet ExecuteStoredProcedure(int id, int topNum, out int count, params string[] strWhere) {
			return dbExec.ExecuteProcedure("proc_T_UserInfo", id, topNum, out count, strWhere);
		}

		public DataTable ExecuteSql(string sql) {
			return dbExec.Query(sql.ToString(), transaction, "UserInfo");
		}

		public int ExecuteSqlCount(string sql) {
			return dbExec.ExecuteCountSql(sql, transaction);
		}

		public int AddRow(UserInfoModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("INSERT INTO UserInfo(");
			strSQL.Append("type, status, userName, isActive, account, password, mobile, tel, email, lastLoginTime, remark)");
			strSQL.Append("VALUES(");
			strSQL.Append("@type, @status, @userName, @isActive, @account, @password, @mobile, @tel, @email, @lastLoginTime, @remark);SELECT @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@type", SqlDbType.Int, 4),
				new SqlParameter("@status", SqlDbType.Int, 4),
				new SqlParameter("@userName", SqlDbType.VarChar, 50),
				new SqlParameter("@isActive", SqlDbType.Bit, 1),
				new SqlParameter("@account", SqlDbType.VarChar, 50),
				new SqlParameter("@password", SqlDbType.Image, 2147483647),
				new SqlParameter("@mobile", SqlDbType.VarChar, 50),
				new SqlParameter("@tel", SqlDbType.VarChar, 50),
				new SqlParameter("@email", SqlDbType.VarChar, 128),
				new SqlParameter("@lastLoginTime", SqlDbType.DateTime, 8),
				new SqlParameter("@remark", SqlDbType.VarChar, 512)
				};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Status;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.IsActive;
			parameters[4].Value = model.Account;
			parameters[5].Value = model.Password;
			parameters[6].Value = model.Mobile;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.LastLoginTime;
			if (model.LastLoginTime == DateTime.MinValue)
				parameters[9].Value = DBNull.Value;
			parameters[10].Value = model.Remark;

			return dbExec.ExecuteAddSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRow(UserInfoModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE UserInfo SET ");
			strSQL.Append("type = @type,");
			strSQL.Append("status = @status,");
			strSQL.Append("userName = @userName,");
			strSQL.Append("isActive = @isActive,");
			strSQL.Append("account = @account,");
			strSQL.Append("password = @password,");
			strSQL.Append("mobile = @mobile,");
			strSQL.Append("tel = @tel,");
			strSQL.Append("email = @email,");
			strSQL.Append("lastLoginTime = @lastLoginTime,");
			strSQL.Append("remark = @remark");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@type", SqlDbType.Int, 4),
				new SqlParameter("@status", SqlDbType.Int, 4),
				new SqlParameter("@userName", SqlDbType.VarChar, 50),
				new SqlParameter("@isActive", SqlDbType.Bit, 1),
				new SqlParameter("@account", SqlDbType.VarChar, 50),
				new SqlParameter("@password", SqlDbType.Image, 2147483647),
				new SqlParameter("@mobile", SqlDbType.VarChar, 50),
				new SqlParameter("@tel", SqlDbType.VarChar, 50),
				new SqlParameter("@email", SqlDbType.VarChar, 128),
				new SqlParameter("@lastLoginTime", SqlDbType.DateTime, 8),
				new SqlParameter("@remark", SqlDbType.VarChar, 512)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.IsActive;
			parameters[5].Value = model.Account;
			parameters[6].Value = model.Password;
			parameters[7].Value = model.Mobile;
			parameters[8].Value = model.Tel;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.LastLoginTime;
			if (model.LastLoginTime == DateTime.MinValue)
				parameters[10].Value = DBNull.Value;
			parameters[11].Value = model.Remark;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void UpdateRowWithLogicKey(UserInfoModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("UPDATE UserInfo SET ");
			strSQL.Append("type = @type,");
			strSQL.Append("status = @status,");
			strSQL.Append("userName = @userName,");
			strSQL.Append("isActive = @isActive,");
			strSQL.Append("password = @password,");
			strSQL.Append("mobile = @mobile,");
			strSQL.Append("tel = @tel,");
			strSQL.Append("email = @email,");
			strSQL.Append("lastLoginTime = @lastLoginTime,");
			strSQL.Append("remark = @remark");
			strSQL.Append(" WHERE ");
			strSQL.Append("account = @account ");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@type", SqlDbType.Int, 4),
				new SqlParameter("@status", SqlDbType.Int, 4),
				new SqlParameter("@userName", SqlDbType.VarChar, 50),
				new SqlParameter("@isActive", SqlDbType.Bit, 1),
				new SqlParameter("@account", SqlDbType.VarChar, 50),
				new SqlParameter("@password", SqlDbType.Image, 2147483647),
				new SqlParameter("@mobile", SqlDbType.VarChar, 50),
				new SqlParameter("@tel", SqlDbType.VarChar, 50),
				new SqlParameter("@email", SqlDbType.VarChar, 128),
				new SqlParameter("@lastLoginTime", SqlDbType.DateTime, 8),
				new SqlParameter("@remark", SqlDbType.VarChar, 512)
				};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.IsActive;
			parameters[5].Value = model.Account;
			parameters[6].Value = model.Password;
			parameters[7].Value = model.Mobile;
			parameters[8].Value = model.Tel;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.LastLoginTime;
			if (model.LastLoginTime == DateTime.MinValue)
				parameters[10].Value = DBNull.Value;
			parameters[11].Value = model.Remark;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRow(UserInfoModel model) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM UserInfo");
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
			strSQL.Append("DELETE FROM UserInfo");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithLogicKey(string account) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM UserInfo");
			strSQL.Append(" WHERE ");
			strSQL.Append("account = @account");
			SqlParameter[] parameters = {
				new SqlParameter("@account", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = account;

			dbExec.ExecuteSql(strSQL.ToString(), transaction, parameters);
		}

		public void DeleteRowWithParam(string strWhere) {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("DELETE FROM UserInfo ");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere);
			}
			dbExec.ExecuteSql(strSQL.ToString(), transaction);
		}

		public DataRow GetSingleRow(int id) {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM UserInfo");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = @id");
			SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int, 4)
				};
			parameters[0].Value = id;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataRow GetSingleRowWithLogicKey(string account) {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM UserInfo");
			strSQL.Append(" WHERE ");
			strSQL.Append("account = @account");
			SqlParameter[] parameters = {
				new SqlParameter("@account", SqlDbType.VarChar, 50)
				};
			parameters[0].Value = account;

			return dbExec.GetSingleRow(strSQL.ToString(), transaction, parameters);
		}

		public DataTable GetVTable(params string[] strWhere) {
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM vUserInfo");
			if (strWhere.Length > 0) {
				strSQL.Append(" WHERE " + strWhere[0]);
			}
			return dbExec.Query(strSQL.ToString(), transaction, "vUserInfo");
		}

		public DataRow GetLastRow() {
			UserInfoModel model = new UserInfoModel();
			StringBuilder strSQL = new StringBuilder();
			strSQL.Append("SELECT * FROM UserInfo");
			strSQL.Append(" WHERE ");
			strSQL.Append("id = ");
			strSQL.Append("(SELECT max(id) FROM UserInfo)");
			return dbExec.GetSingleRow(strSQL.ToString(), transaction);
		}

	}
}
