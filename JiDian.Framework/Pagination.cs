using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace JiDian.Framework {
	public class Pagination {

		public Pagination(int pageSize) {
			this.pageSize = pageSize;
		}


		public DataTable GetPageData(string tableName, string returnFields, string orderField, int pageSize, int pageIndex, int orderType, string strWhere, out int count) {
			DataTable dt = null;
			count = 0;
			SqlConnection conn = null;
			try {
				dt = new DataTable();
				conn = new SqlConnection(ApplicationConfig.ConnectionString());
				conn.Open();

				SqlCommand command = new SqlCommand();
				command.Connection = conn;
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "[dbo].[pagination]";
				command.Parameters.AddRange(new SqlParameter[]{
                    new SqlParameter("@tableName", tableName),
                    new SqlParameter("@returnFields", returnFields),
                    new SqlParameter("@orderField", orderField),
                    new SqlParameter("@pageSize", pageSize),
                    new SqlParameter("@pageIndex", pageIndex),
                    new SqlParameter("@count",SqlDbType.Int),
                    new SqlParameter("@orderType", orderType),
                    new SqlParameter("@strWhere", strWhere)});
				command.Parameters["@count"].Direction = ParameterDirection.Output;
				SqlDataAdapter adapter = new SqlDataAdapter();
				adapter.SelectCommand = command;
				adapter.Fill(dt);
				count = Convert.ToInt32(command.Parameters["@count"].Value);
			}
			catch (SqlException ex) {
				throw ex;
			}
			finally {
				if (conn.State == ConnectionState.Open) {
					conn.Close();
				}
			}
			return dt;
		}

		public int CalcPageIndex(int dataStart) {
			return dataStart / pageSize + 1;
		}

		private int pageSize = 15;
		public int PageSize {
			get {
				return pageSize;
			}
			set {
				pageSize = value;
			}
		}
	}

}
