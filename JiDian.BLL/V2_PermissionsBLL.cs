using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using JiDian.Model;
using JiDian.DAL;

namespace JiDian.BLL {
	public partial class V2_PermissionsBLL {
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		private V2_PermissionsDAL dal = null;
		private bool disposed = false;
		private bool selfConn = false;
		public V2_PermissionsBLL() {
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
				dal = new V2_PermissionsDAL(connection, transaction);
			}
		}
		public V2_PermissionsBLL(SqlConnection connection) {
			this.connection = connection;
			dal = new V2_PermissionsDAL(connection, transaction);
		}
		public V2_PermissionsBLL(SqlConnection connection, SqlTransaction transaction) {
			this.connection = connection;
			this.transaction = transaction;
			dal = new V2_PermissionsDAL(connection, transaction);
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

		public bool ExistsWithLogicKey(int page_id, string permission_key) {
			return dal.ExistsWithLogicKey(page_id, permission_key);
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

		public List<V2_PermissionsModel> GetList(params string[] strWhere) {
			DataTable dt = dal.GetTable(strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_PermissionsModel> GetTopList(int topNum, params string[] strWhere) {
			DataTable dt = dal.GetTopTable(topNum, strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_PermissionsModel> GetListFromTable(DataTable dt) {
			List<V2_PermissionsModel> models = new List<V2_PermissionsModel>();
			foreach (DataRow dr in dt.Rows) {
				V2_PermissionsModel model = new V2_PermissionsModel();
				if (dr["id"] != DBNull.Value)
					model.Id = Convert.ToInt32(dr["id"]);
				if (dr["page_id"] != DBNull.Value)
					model.Page_id = Convert.ToInt32(dr["page_id"]);
				if (dr["permission_name"] != DBNull.Value)
					model.Permission_name = Convert.ToString(dr["permission_name"]);
				if (dr["permission_key"] != DBNull.Value)
					model.Permission_key = Convert.ToString(dr["permission_key"]);
				if (dr["offset"] != DBNull.Value)
					model.Offset = Convert.ToInt32(dr["offset"]);
				models.Add(model);
			}
			return models;
		}

		public int GetCount(params string[] strWhere) {
			return dal.GetCount(strWhere);
		}

		public List<V2_PermissionsModel> GetListFromSql(string sql) {
			DataTable table = dal.ExecuteSql(sql);
			return GetListFromTable(table);
		}

		public int ExecuteSqlCount(string sql) {
			return dal.ExecuteSqlCount(sql);
		}

		public int AddRow(V2_PermissionsModel model) {
			return dal.AddRow(model);
		}

		public void UpdateRow(V2_PermissionsModel model) {
			dal.UpdateRow(model);
		}

		public void UpdateRowWithLogicKey(V2_PermissionsModel model) {
			dal.UpdateRowWithLogicKey(model);
		}

		public void DeleteRow(V2_PermissionsModel model) {
			dal.DeleteRow(model);
		}

		public void DeleteRow(int id) {
			dal.DeleteRow(id);
		}

		public void DeleteRowWithLogicKey(int page_id, string permission_key) {
			dal.DeleteRowWithLogicKey(page_id, permission_key);
		}

		public void DeleteRowWithParam(string strWhere) {
			dal.DeleteRowWithParam(strWhere);
		}

		public DataRow GetSingleRow(int id) {
			return dal.GetSingleRow(id);
		}

		public DataRow GetSingleRowWithLogicKey(int page_id, string permission_key) {
			return dal.GetSingleRowWithLogicKey(page_id, permission_key);
		}

		public V2_PermissionsModel GetModel(int id) {
			DataRow dr = GetSingleRow(id);
			if (dr == null) {
				return null;
			}
			V2_PermissionsModel model = new V2_PermissionsModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["page_id"] != DBNull.Value)
				model.Page_id = Convert.ToInt32(dr["page_id"]);
			if (dr["permission_name"] != DBNull.Value)
				model.Permission_name = Convert.ToString(dr["permission_name"]);
			if (dr["permission_key"] != DBNull.Value)
				model.Permission_key = Convert.ToString(dr["permission_key"]);
			if (dr["offset"] != DBNull.Value)
				model.Offset = Convert.ToInt32(dr["offset"]);
			return model;
		}

		public V2_PermissionsModel GetModelWithLogicKey(int page_id, string permission_key) {
			DataRow dr = dal.GetSingleRowWithLogicKey(page_id, permission_key);
			if (dr == null) {
				return null;
			}
			V2_PermissionsModel model = new V2_PermissionsModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["page_id"] != DBNull.Value)
				model.Page_id = Convert.ToInt32(dr["page_id"]);
			if (dr["permission_name"] != DBNull.Value)
				model.Permission_name = Convert.ToString(dr["permission_name"]);
			if (dr["permission_key"] != DBNull.Value)
				model.Permission_key = Convert.ToString(dr["permission_key"]);
			if (dr["offset"] != DBNull.Value)
				model.Offset = Convert.ToInt32(dr["offset"]);
			return model;
		}

		public DataTable GetVTable(params string[] strWhere) {
			return dal.GetVTable(strWhere);
		}

		public DataRow GetLastRow() {
			return dal.GetLastRow();
		}

		public V2_PermissionsModel GetLastModel() {
			DataRow dr = GetLastRow();
			if (dr == null) {
				return null;
			}
			V2_PermissionsModel model = new V2_PermissionsModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["page_id"] != DBNull.Value)
				model.Page_id = Convert.ToInt32(dr["page_id"]);
			if (dr["permission_name"] != DBNull.Value)
				model.Permission_name = Convert.ToString(dr["permission_name"]);
			if (dr["permission_key"] != DBNull.Value)
				model.Permission_key = Convert.ToString(dr["permission_key"]);
			if (dr["offset"] != DBNull.Value)
				model.Offset = Convert.ToInt32(dr["offset"]);
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
