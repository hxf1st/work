using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using JiDian.BLL;
using JiDian.Model;

namespace JiDian.Framework.Cache {
	public class V2_UserPermissionCache {
		private static Dictionary<int, BitArray> dict;

		public static Dictionary<int, BitArray> GetCache() {
			if (dict == null) {
				UpdateCache();
			}
			return dict;
		}

		private static void UpdateCache() {
			dict = new Dictionary<int, BitArray>();

			Dictionary<int, BitArray> rcache = V2_RoleCache.GetCache();
			V2_User_RoleBLL bll = new V2_User_RoleBLL();
			try {
				List<V2_User_RoleModel> list = bll.GetList();
				foreach (V2_User_RoleModel model in list) {
					if (dict.ContainsKey(model.User_id)) {
						BitArray bitArray = dict[model.User_id];
						bitArray = bitArray.Or(rcache[model.Role_id]);
					}
					else {
						BitArray array = new BitArray(8000 * 4);
						array = array.Or(rcache[model.Role_id]);
						dict.Add(model.User_id, array);
					}
				}
			}
			finally {
				bll.Dispose();
			}
		}

		public static void ClearCache() {
			dict = null;
		}
	}
}
