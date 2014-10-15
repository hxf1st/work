using System;
using System.Collections.Generic;
using System.Text;
using JiDian.BLL;
using JiDian.Model;

namespace JiDian.Framework.Cache {
	public class V2_PermissionsCache {

		private static Dictionary<string, List<V2_PermissionsModel>> dict;
		public static Dictionary<string, List<V2_PermissionsModel>> GetCache() {
			if (dict == null) {
				UpdateCache();
			}
			return dict;
		}
		private static void UpdateCache() {
			dict = new Dictionary<string, List<V2_PermissionsModel>>();

			V2_PagesBLL pagebll = new V2_PagesBLL();
			List<V2_PagesModel> pagelist = pagebll.GetList();

			V2_PermissionsBLL bll = new V2_PermissionsBLL();
			foreach (V2_PagesModel pmodel in pagelist) {
				List<V2_PermissionsModel> list = bll.GetList("page_id=" + pmodel.Id);

				if(!dict.ContainsKey(pmodel.Url.ToLower())){
					dict.Add(pmodel.Url.ToLower(), list);
				}
			}

			pagebll.Dispose();
			bll.Dispose();
		}


		private static Dictionary<string, V2_PermissionsModel> dictPermission;
		public static Dictionary<string, V2_PermissionsModel> GetPermissionCache() {
			if (dictPermission == null) {
				UpdatePermissionCache();
			}
			return dictPermission;
		}
		private static void UpdatePermissionCache() {
			dictPermission = new Dictionary<string, V2_PermissionsModel>();

			Dictionary<string, List<V2_PermissionsModel>> dict = GetCache();
			foreach (string url in dict.Keys) {
				List<V2_PermissionsModel> list = dict[url];

				foreach (V2_PermissionsModel model in list) {
					string key = url + "&&&" + model.Permission_key;
					if (!dictPermission.ContainsKey(key)) {
						dictPermission.Add(key, model);
					}
				}
			}
		}

		public static void ClearCache() {
			dict = null;
			dictPermission = null;
		}
	}
}
