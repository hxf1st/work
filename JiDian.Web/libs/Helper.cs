using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JiDian.Framework;
using System.Data;
using JiDian.Model;
using System.Reflection;

namespace JiDian.Web.libs {
	public static class Helper {

		static IntEncode encode = new IntEncode();

		public static int Id_Decode(string src, string id_prefix) {
			if (src == "") return 0;

			string decodeStr = encode.Decode(src);
			string[] arr = decodeStr.Split('_');
			if (arr[0] != id_prefix) {
				throw new Exception("wrong id prefix");
			}
			else {
				return Convert.ToInt32(arr[1]);
			}
		}

		public static string Id_Encode(int value, string id_prefix) {
			return encode.Encode(id_prefix + "_" + value);
		}

		public static List<T> ConvertDataTableToList<T>(DataTable dt) where T : new() {

			T model = new T();
			PropertyInfo[] property = model.GetType().GetProperties();

			List<T> list = new List<T>();
			foreach (DataRow row in dt.Rows) {
				T data = new T();
				foreach (PropertyInfo p in property) {
					p.SetValue(data, row[p.Name], null);
				}
				list.Add(data);
			}

			return list;
		}

		public static List<T> ConvertDataTableToListWithEncrypt<T>(DataTable dt, string prefix) where T : new() {

			T model = new T();
			PropertyInfo[] property = model.GetType().GetProperties();

			List<T> list = new List<T>();
			foreach (DataRow row in dt.Rows) {
				T data = new T();
				foreach (PropertyInfo p in property) {
					if (p.Name.ToLower() == "id_ex") {
						if (data is BaseModel)
							(data as BaseModel).Id_Ex = Id_Encode(Convert.ToInt32(row["id"]), prefix);
					}
					else {
						p.SetValue(data, row[p.Name], null);
					}
				}
				list.Add(data);
			}

			return list;
		}
	}
}
