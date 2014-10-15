using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using JiDian.Model;
using JiDian.DAL;

namespace JiDian.BLL {
	public partial class V2_User_RoleBLL {
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		private V2_User_RoleDAL dal = null;
		private bool disposed = false;
		private bool selfConn = false;
		public V2_User_RoleBLL() {
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
				dal = new V2_User_RoleDAL(connection, transaction);
			}
		}
		public V2_User_RoleBLL(SqlConnection connection) {
			this.connection = connection;
			dal = new V2_User_RoleDAL(connection, transaction);
		}
		public V2_User_RoleBLL(SqlConnection connection, SqlTransaction transaction) {
			this.connection = connection;
			this.transaction = transaction;
			dal = new V2_User_RoleDAL(connection, transaction);
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


		public bool ExistsWithParam(string strWhere) {
			return dal.ExistsWithParam(strWhere);
		}

		public DataTable GetTable(params string[] strWhere) {
			return dal.GetTable(strWhere);
		}

		public DataTable GetTopTable(int topNum, params string[] strWhere) {
			return dal.GetTopTable(topNum, strWhere);
		}

		public List<V2_User_RoleModel> GetList(params string[] strWhere) {
			DataTable dt = dal.GetTable(strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_User_RoleModel> GetTopList(int topNum, params string[] strWhere) {
			DataTable dt = dal.GetTopTable(topNum, strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_User_RoleModel> GetListFromTable(DataTable dt) {
			List<V2_User_RoleModel> models = new List<V2_User_RoleModel>();
			foreach (DataRow dr in dt.Rows) {
				V2_User_RoleModel model = new V2_User_RoleModel();
				if (dr["id"] != DBNull.Value)
					model.Id = Convert.ToInt32(dr["id"]);
				if (dr["user_id"] != DBNull.Value)
					model.User_id = Convert.ToInt32(dr["user_id"]);
				if (dr["role_id"] != DBNull.Value)
					model.Role_id = Convert.ToInt32(dr["role_id"]);
				models.Add(model);
			}
			return models;
		}

		public int GetCount(params string[] strWhere) {
			return dal.GetCount(strWhere);
		}

		public List<V2_User_RoleModel> GetListFromSql(string sql) {
			DataTable table = dal.ExecuteSql(sql);
			return GetListFromTable(table);
		}

		public int ExecuteSqlCount(string sql) {
			return dal.ExecuteSqlCount(sql);
		}

		public int AddRow(V2_User_RoleModel model) {
			return dal.AddRow(model);
		}

		public void UpdateRow(V2_User_RoleModel model) {
			dal.UpdateRow(model);
		}


		public void DeleteRow(V2_User_RoleModel model) {
			dal.DeleteRow(model);
		}

		public void DeleteRow(int id) {
			dal.DeleteRow(id);
		}


		public void DeleteRowWithParam(string strWhere) {
			dal.DeleteRowWithParam(strWhere);
		}

		public DataRow GetSingleRow(int id) {
			return dal.GetSingleRow(id);
		}


		public V2_User_RoleModel GetModel(int id) {
			DataRow dr = GetSingleRow(id);
			if (dr == null) {
				return null;
			}
			V2_User_RoleModel model = new V2_User_RoleModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["user_id"] != DBNull.Value)
				model.User_id = Convert.ToInt32(dr["user_id"]);
			if (dr["role_id"] != DBNull.Value)
				model.Role_id = Convert.ToInt32(dr["role_id"]);
			return model;
		}


		public DataTable GetVTable(params string[] strWhere) {
			return dal.GetVTable(strWhere);
		}

		public DataRow GetLastRow() {
			return dal.GetLastRow();
		}

		public V2_User_RoleModel GetLastModel() {
			DataRow dr = GetLastRow();
			if (dr == null) {
				return null;
			}
			V2_User_RoleModel model = new V2_User_RoleModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["user_id"] != DBNull.Value)
				model.User_id = Convert.ToInt32(dr["user_id"]);
			if (dr["role_id"] != DBNull.Value)
				model.Role_id = Convert.ToInt32(dr["role_id"]);
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
