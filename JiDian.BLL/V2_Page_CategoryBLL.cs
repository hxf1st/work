using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using JiDian.Model;
using JiDian.DAL;

namespace JiDian.BLL {
	public partial class V2_Page_CategoryBLL {
		private SqlTransaction transaction = null;
		private SqlConnection connection = null;
		private V2_Page_CategoryDAL dal = null;
		private bool disposed = false;
		private bool selfConn = false;
		public V2_Page_CategoryBLL() {
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
				dal = new V2_Page_CategoryDAL(connection, transaction);
			}
		}
		public V2_Page_CategoryBLL(SqlConnection connection) {
			this.connection = connection;
			dal = new V2_Page_CategoryDAL(connection, transaction);
		}
		public V2_Page_CategoryBLL(SqlConnection connection, SqlTransaction transaction) {
			this.connection = connection;
			this.transaction = transaction;
			dal = new V2_Page_CategoryDAL(connection, transaction);
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

		public List<V2_Page_CategoryModel> GetList(params string[] strWhere) {
			DataTable dt = dal.GetTable(strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_Page_CategoryModel> GetTopList(int topNum, params string[] strWhere) {
			DataTable dt = dal.GetTopTable(topNum, strWhere);
			return GetListFromTable(dt);
		}

		public List<V2_Page_CategoryModel> GetListFromTable(DataTable dt) {
			List<V2_Page_CategoryModel> models = new List<V2_Page_CategoryModel>();
			foreach (DataRow dr in dt.Rows) {
				V2_Page_CategoryModel model = new V2_Page_CategoryModel();
				if (dr["id"] != DBNull.Value)
					model.Id = Convert.ToInt32(dr["id"]);
				if (dr["category_name"] != DBNull.Value)
					model.Category_name = Convert.ToString(dr["category_name"]);
				if (dr["ordernum"] != DBNull.Value)
					model.Ordernum = Convert.ToInt32(dr["ordernum"]);
				models.Add(model);
			}
			return models;
		}

		public int GetCount(params string[] strWhere) {
			return dal.GetCount(strWhere);
		}

		public List<V2_Page_CategoryModel> GetListFromSql(string sql) {
			DataTable table = dal.ExecuteSql(sql);
			return GetListFromTable(table);
		}

		public int ExecuteSqlCount(string sql) {
			return dal.ExecuteSqlCount(sql);
		}

		public int AddRow(V2_Page_CategoryModel model) {
			return dal.AddRow(model);
		}

		public void UpdateRow(V2_Page_CategoryModel model) {
			dal.UpdateRow(model);
		}


		public void DeleteRow(V2_Page_CategoryModel model) {
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


		public V2_Page_CategoryModel GetModel(int id) {
			DataRow dr = GetSingleRow(id);
			if (dr == null) {
				return null;
			}
			V2_Page_CategoryModel model = new V2_Page_CategoryModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["category_name"] != DBNull.Value)
				model.Category_name = Convert.ToString(dr["category_name"]);
			if (dr["ordernum"] != DBNull.Value)
				model.Ordernum = Convert.ToInt32(dr["ordernum"]);
			return model;
		}


		public DataTable GetVTable(params string[] strWhere) {
			return dal.GetVTable(strWhere);
		}

		public DataRow GetLastRow() {
			return dal.GetLastRow();
		}

		public V2_Page_CategoryModel GetLastModel() {
			DataRow dr = GetLastRow();
			if (dr == null) {
				return null;
			}
			V2_Page_CategoryModel model = new V2_Page_CategoryModel();
			if (dr["id"] != DBNull.Value)
				model.Id = Convert.ToInt32(dr["id"]);
			if (dr["category_name"] != DBNull.Value)
				model.Category_name = Convert.ToString(dr["category_name"]);
			if (dr["ordernum"] != DBNull.Value)
				model.Ordernum = Convert.ToInt32(dr["ordernum"]);
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
