using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using JiDian.Model;
using JiDian.DAL;

namespace JiDian.BLL {
	public partial class V2_PagesBLL {
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		private V2_PagesDAL dal = null;
		private bool disposed = false;
		private bool selfConn = false;
		public V2_PagesBLL() {
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
				dal = new V2_PagesDAL(connection, transaction);
			}
		}
		public V2_PagesBLL(SqlConnection connection) {
			this.connection = connection;
			dal = new V2_PagesDAL(connection, transaction);
		}
		public V2_PagesBLL(SqlConnection connection, SqlTransaction transaction) {
			this.connection = connection;
			this.transaction = transaction;
			dal = new V2_PagesDAL(connection, transaction);
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

		public bool ExistsWithLogicKey(string url) {
			return dal.ExistsWithLogicKey(url);
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

		public List<V2_PagesModel> GetList(params string[] strWhere) {
			DataTable dt = dal.GetTable(strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_PagesModel> GetTopList(int topNum, params string[] strWhere) {
			DataTable dt = dal.GetTopTable(topNum, strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_PagesModel> GetListFromTable(DataTable dt) {
			List<V2_PagesModel> models = new List<V2_PagesModel>();
			foreach (DataRow dr in dt.Rows) {
				V2_PagesModel model = new V2_PagesModel();
				if (dr["id"] != DBNull.Value)
					model.Id = Convert.ToInt32(dr["id"]);
				if (dr["category_id"] != DBNull.Value)
					model.Category_id = Convert.ToInt32(dr["category_id"]);
				if (dr["page_name"] != DBNull.Value)
					model.Page_name = Convert.ToString(dr["page_name"]);
				if (dr["url"] != DBNull.Value)
					model.Url = Convert.ToString(dr["url"]);
				if (dr["ordernum"] != DBNull.Value)
					model.Ordernum = Convert.ToInt32(dr["ordernum"]);
				if (dr["isnav"] != DBNull.Value)
					model.Isnav = Convert.ToInt32(dr["isnav"]);
				if (dr["remark"] != DBNull.Value)
					model.Remark = Convert.ToString(dr["remark"]);
				models.Add(model);
			}
			return models;
		}

		public int GetCount(params string[] strWhere) {
			return dal.GetCount(strWhere);
		}

		public List<V2_PagesModel> GetListFromSql(string sql) {
			DataTable table = dal.ExecuteSql(sql);
			return GetListFromTable(table);
		}

		public int ExecuteSqlCount(string sql) {
			return dal.ExecuteSqlCount(sql);
		}

		public int AddRow(V2_PagesModel model) {
			return dal.AddRow(model);
		}

		public void UpdateRow(V2_PagesModel model) {
			dal.UpdateRow(model);
		}

		public void UpdateRowWithLogicKey(V2_PagesModel model) {
			dal.UpdateRowWithLogicKey(model);
		}

		public void DeleteRow(V2_PagesModel model) {
			dal.DeleteRow(model);
		}

		public void DeleteRow(int id) {
			dal.DeleteRow(id);
		}

		public void DeleteRowWithLogicKey(string url) {
			dal.DeleteRowWithLogicKey(url);
		}

		public void DeleteRowWithParam(string strWhere) {
			dal.DeleteRowWithParam(strWhere);
		}

		public DataRow GetSingleRow(int id) {
			return dal.GetSingleRow(id);
		}

		public DataRow GetSingleRowWithLogicKey(string url) {
			return dal.GetSingleRowWithLogicKey(url);
		}

		public V2_PagesModel GetModel(int id) {
			DataRow dr = GetSingleRow(id);
			if (dr == null) {
				return null;
			}
			V2_PagesModel model = new V2_PagesModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["category_id"] != DBNull.Value)
				model.Category_id = Convert.ToInt32(dr["category_id"]);
			if (dr["page_name"] != DBNull.Value)
				model.Page_name = Convert.ToString(dr["page_name"]);
			if (dr["url"] != DBNull.Value)
				model.Url = Convert.ToString(dr["url"]);
			if (dr["ordernum"] != DBNull.Value)
				model.Ordernum = Convert.ToInt32(dr["ordernum"]);
			if (dr["isnav"] != DBNull.Value)
				model.Isnav = Convert.ToInt32(dr["isnav"]);
			if (dr["remark"] != DBNull.Value)
				model.Remark = Convert.ToString(dr["remark"]);
			return model;
		}

		public V2_PagesModel GetModelWithLogicKey(string url) {
			DataRow dr = dal.GetSingleRowWithLogicKey(url);
			if (dr == null) {
				return null;
			}
			V2_PagesModel model = new V2_PagesModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["category_id"] != DBNull.Value)
				model.Category_id = Convert.ToInt32(dr["category_id"]);
			if (dr["page_name"] != DBNull.Value)
				model.Page_name = Convert.ToString(dr["page_name"]);
			if (dr["url"] != DBNull.Value)
				model.Url = Convert.ToString(dr["url"]);
			if (dr["ordernum"] != DBNull.Value)
				model.Ordernum = Convert.ToInt32(dr["ordernum"]);
			if (dr["isnav"] != DBNull.Value)
				model.Isnav = Convert.ToInt32(dr["isnav"]);
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

		public V2_PagesModel GetLastModel() {
			DataRow dr = GetLastRow();
			if (dr == null) {
				return null;
			}
			V2_PagesModel model = new V2_PagesModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["category_id"] != DBNull.Value)
				model.Category_id = Convert.ToInt32(dr["category_id"]);
			if (dr["page_name"] != DBNull.Value)
				model.Page_name = Convert.ToString(dr["page_name"]);
			if (dr["url"] != DBNull.Value)
				model.Url = Convert.ToString(dr["url"]);
			if (dr["ordernum"] != DBNull.Value)
				model.Ordernum = Convert.ToInt32(dr["ordernum"]);
			if (dr["isnav"] != DBNull.Value)
				model.Isnav = Convert.ToInt32(dr["isnav"]);
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
