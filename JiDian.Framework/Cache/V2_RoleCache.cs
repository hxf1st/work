using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using JiDian.BLL;
using JiDian.Model;

namespace JiDian.Framework.Cache {
	public class V2_RoleCache {

		private static Dictionary<int, BitArray> dict;

		public static Dictionary<int, BitArray> GetCache() {
			if (dict == null) {
				UpdateCache();
			}
			return dict;
		}

		private static void UpdateCache() {
			dict = new Dictionary<int, BitArray>();
			V2_RoleBLL bll = new V2_RoleBLL();
			try {
				List<V2_RoleModel> list = bll.GetList();
				foreach (V2_RoleModel model in list) {
					if (!dict.ContainsKey(model.Id)) {
						BitArray array = new BitArray(model.Permission);
						dict.Add(model.Id, array);
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
