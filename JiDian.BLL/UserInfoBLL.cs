using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using JiDian.Model;
using JiDian.DAL;

namespace JiDian.BLL {
	public partial class UserInfoBLL {
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		private UserInfoDAL dal = null;
		private bool disposed = false;
		private bool selfConn = false;
		public UserInfoBLL() {
			connection = new SqlConnection();
			connection.ConnectionString = ApplicationConfig.ConnectionString();
			try {
				connection.Open();
				selfConn = true;
			}
			catch {
				connection.ConnectionString = ApplicationConfig.UpdateCache();
				connection.Open();
				selfConn = true;
			}
			finally {
				dal = new UserInfoDAL(connection, transaction);
			}
		}
		public UserInfoBLL(SqlConnection connection) {
			this.connection = connection;
			dal = new UserInfoDAL(connection, transaction);
		}
		public UserInfoBLL(SqlConnection connection, SqlTransaction transaction) {
			this.connection = connection;
			this.transaction = transaction;
			dal = new UserInfoDAL(connection, transaction);
		}
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
			return dal.Exists(id);
		}

		public bool ExistsWithLogicKey(string account) {
			return dal.ExistsWithLogicKey(account);
		}

		public bool ExistsWithParam(string strWhere) {
			return dal.ExistsWithParam(strWhere);
		}

		public DataTable GetTable(params string[] strWhere) {
			return dal.GetTable(strWhere);
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			return dal.GetTopTable(topNum, strWhere);
		}

		public List<UserInfoModel> GetList(params string[] strWhere) {
			DataTable dt = dal.GetTable(strWhere);
			return GetListFromTable(dt);
		}

		public List<UserInfoModel> GetTopList(int topNum, params string[] strWhere) {
			DataTable dt = dal.GetTopTable(topNum, strWhere);
			return GetListFromTable(dt);
		}

		public List<UserInfoModel> GetListFromTable(DataTable dt) {
			List<UserInfoModel> models = new List<UserInfoModel>();
			foreach (DataRow dr in dt.Rows) {
				UserInfoModel model = new UserInfoModel();
				if (dr["id"] != DBNull.Value)
					model.Id = Convert.ToInt32(dr["id"]);
				if (dr["type"] != DBNull.Value)
					model.Type = Convert.ToInt32(dr["type"]);
				if (dr["status"] != DBNull.Value)
					model.Status = Convert.ToInt32(dr["status"]);
				if (dr["userName"] != DBNull.Value)
					model.UserName = Convert.ToString(dr["userName"]);
				if (dr["isActive"] != DBNull.Value)
					model.IsActive = Convert.ToBoolean(dr["isActive"]);
				if (dr["account"] != DBNull.Value)
					model.Account = Convert.ToString(dr["account"]);
				if (dr["password"] != DBNull.Value)
					model.Password = (byte[])dr["password"];
				if (dr["mobile"] != DBNull.Value)
					model.Mobile = Convert.ToString(dr["mobile"]);
				if (dr["tel"] != DBNull.Value)
					model.Tel = Convert.ToString(dr["tel"]);
				if (dr["email"] != DBNull.Value)
					model.Email = Convert.ToString(dr["email"]);
				if (dr["lastLoginTime"] != DBNull.Value)
					model.LastLoginTime = Convert.ToDateTime(dr["lastLoginTime"]);
				if (dr["remark"] != DBNull.Value)
					model.Remark = Convert.ToString(dr["remark"]);
				models.Add(model);
			}
			return models;
		}

		public int GetCount(params string[] strWhere) {
			return dal.GetCount(strWhere);
		}

		public DataSet ExecuteStoredProcedure(int id, int topNum, out int count, params string[] strWhere) {
			return dal.ExecuteStoredProcedure(id, topNum, out count, strWhere);
		}

		public List<UserInfoModel> GetListFromSql(string sql) {
			DataTable table = dal.ExecuteSql(sql);
			return GetListFromTable(table);
		}

		public int ExecuteSqlCount(string sql) {
			return dal.ExecuteSqlCount(sql);
		}

		public int AddRow(UserInfoModel model) {
			return dal.AddRow(model);
		}

		public void UpdateRow(UserInfoModel model) {
			dal.UpdateRow(model);
		}

		public void UpdateRowWithLogicKey(UserInfoModel model) {
			dal.UpdateRowWithLogicKey(model);
		}

		public void DeleteRow(UserInfoModel model) {
			dal.DeleteRow(model);
		}

		public void DeleteRow(int id) {
			dal.DeleteRow(id);
		}

		public void DeleteRowWithLogicKey(string account) {
			dal.DeleteRowWithLogicKey(account);
		}

		public void DeleteRowWithParam(string strWhere) {
			dal.DeleteRowWithParam(strWhere);
		}

		public DataRow GetSingleRow(int id) {
			return dal.GetSingleRow(id);
		}

		public DataRow GetSingleRowWithLogicKey(string account) {
			return dal.GetSingleRowWithLogicKey(account);
		}

		public UserInfoModel GetModel(int id) {
			DataRow dr = GetSingleRow(id);
			if (dr == null) {
				return null;
			}
			UserInfoModel model = new UserInfoModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["type"] != DBNull.Value)
				model.Type = Convert.ToInt32(dr["type"]);
			if (dr["status"] != DBNull.Value)
				model.Status = Convert.ToInt32(dr["status"]);
			if (dr["userName"] != DBNull.Value)
				model.UserName = Convert.ToString(dr["userName"]);
			if (dr["isActive"] != DBNull.Value)
				model.IsActive = Convert.ToBoolean(dr["isActive"]);
			if (dr["account"] != DBNull.Value)
				model.Account = Convert.ToString(dr["account"]);
			if (dr["password"] != DBNull.Value)
				model.Password = (byte[])dr["password"];
			if (dr["mobile"] != DBNull.Value)
				model.Mobile = Convert.ToString(dr["mobile"]);
			if (dr["tel"] != DBNull.Value)
				model.Tel = Convert.ToString(dr["tel"]);
			if (dr["email"] != DBNull.Value)
				model.Email = Convert.ToString(dr["email"]);
			if (dr["lastLoginTime"] != DBNull.Value)
				model.LastLoginTime = Convert.ToDateTime(dr["lastLoginTime"]);
			if (dr["remark"] != DBNull.Value)
				model.Remark = Convert.ToString(dr["remark"]);
			return model;
		}

		public UserInfoModel GetModelWithLogicKey(string account) {
			DataRow dr = dal.GetSingleRowWithLogicKey(account);
			if (dr == null) {
				return null;
			}
			UserInfoModel model = new UserInfoModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["type"] != DBNull.Value)
				model.Type = Convert.ToInt32(dr["type"]);
			if (dr["status"] != DBNull.Value)
				model.Status = Convert.ToInt32(dr["status"]);
			if (dr["userName"] != DBNull.Value)
				model.UserName = Convert.ToString(dr["userName"]);
			if (dr["isActive"] != DBNull.Value)
				model.IsActive = Convert.ToBoolean(dr["isActive"]);
			if (dr["account"] != DBNull.Value)
				model.Account = Convert.ToString(dr["account"]);
			if (dr["password"] != DBNull.Value)
				model.Password = (byte[])dr["password"];
			if (dr["mobile"] != DBNull.Value)
				model.Mobile = Convert.ToString(dr["mobile"]);
			if (dr["tel"] != DBNull.Value)
				model.Tel = Convert.ToString(dr["tel"]);
			if (dr["email"] != DBNull.Value)
				model.Email = Convert.ToString(dr["email"]);
			if (dr["lastLoginTime"] != DBNull.Value)
				model.LastLoginTime = Convert.ToDateTime(dr["lastLoginTime"]);
			if (dr["remark"] != DBNull.Value)
				model.Remark = Convert.ToString(dr["remark"]);
			return model;
		}

		public DataTable GetVTable(params string[] strWhere) {
			return dal.GetVTable(strWhere);
		}

		public DataRow GetLastRow() {
			return dal.GetLastRow();
		}

		public UserInfoModel GetLastModel() {
			DataRow dr = GetLastRow();
			if (dr == null) {
				return null;
			}
			UserInfoModel model = new UserInfoModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["type"] != DBNull.Value)
				model.Type = Convert.ToInt32(dr["type"]);
			if (dr["status"] != DBNull.Value)
				model.Status = Convert.ToInt32(dr["status"]);
			if (dr["userName"] != DBNull.Value)
				model.UserName = Convert.ToString(dr["userName"]);
			if (dr["isActive"] != DBNull.Value)
				model.IsActive = Convert.ToBoolean(dr["isActive"]);
			if (dr["account"] != DBNull.Value)
				model.Account = Convert.ToString(dr["account"]);
			if (dr["password"] != DBNull.Value)
				model.Password = (byte[])dr["password"];
			if (dr["mobile"] != DBNull.Value)
				model.Mobile = Convert.ToString(dr["mobile"]);
			if (dr["tel"] != DBNull.Value)
				model.Tel = Convert.ToString(dr["tel"]);
			if (dr["email"] != DBNull.Value)
				model.Email = Convert.ToString(dr["email"]);
			if (dr["lastLoginTime"] != DBNull.Value)
				model.LastLoginTime = Convert.ToDateTime(dr["lastLoginTime"]);
			if (dr["remark"] != DBNull.Value)
				model.Remark = Convert.ToString(dr["remark"]);
			return model;
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing) {
			if (!this.disposed) {
				if (this.selfConn) {
					if (this.connection.State == ConnectionState.Open) {
						this.connection.Close();
						this.connection.Dispose();
					}
				}
				this.disposed = true;
			}
		}
	}
}
