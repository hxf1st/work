using System;
using System.Collections.Generic;
using System.Text;
using JiDian.Model;
using JiDian.BLL;

namespace JiDian.Framework.Cache {
	public class V2_UserRoleCache {
		private static Dictionary<int, List<int>> dict;

		public static Dictionary<int, List<int>> GetCache() {
			if (dict == null) {
				UpdateCache();
			}
			return dict;
		}

		private static void UpdateCache() {
			dict = new Dictionary<int, List<int>>();

			V2_User_RoleBLL bll = new V2_User_RoleBLL();
			List<V2_User_RoleModel> list = bll.GetList();

			foreach (V2_User_RoleModel model in list) {
				List<int> li = new List<int>();
				if (!dict.ContainsKey(model.User_id)) {
					li.Add(model.Role_id);
					dict.Add(model.User_id, li);
				}
				else {
					li = dict[model.User_id];
					li.Add(model.Role_id);
				}
			}
			bll.Dispose();
		}

		public static void ClearCache() {
			dict = null;
		}
		
	}
}
