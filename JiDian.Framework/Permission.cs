using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JiDian.Model;
using System.Collections;
using JiDian.BLL;
using JiDian.Framework.Cache;


namespace JiDian.Framework {
	/// <summary>
	/// Summary description for Permission
	/// </summary>
	public class Permission {
		public Permission() {
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 当前用户所有权限
		/// </summary>
		/// <returns></returns>
		private static BitArray UserPermission() {
			int userId = UserData.GetUserId();
			Dictionary<int, BitArray> dictUser = V2_UserPermissionCache.GetCache();
			if (dictUser.ContainsKey(userId)) {
				return dictUser[userId];
			}
			else {
				BitArray array = new BitArray(8000 * 4);
				array.SetAll(false);
				return array;
			}
		}
		/// <summary>
		/// 检查页面某个权限
		/// </summary>
		/// <param name="url"></param>
		/// <param name="permission_key"></param>
		/// <returns></returns>
		public static bool CheckPermission(string url, string permission_key) {
			Dictionary<string, V2_PermissionsModel> cache = V2_PermissionsCache.GetPermissionCache();
			string key = url.ToLower() + "&&&" + permission_key;
			if (cache.ContainsKey(key)) {
				V2_PermissionsModel model = cache[key];
				int offest = model.Page_id * 16 + model.Offset;
				return UserPermission().Get(offest);
			}
			return false;
		}

		/// <summary>
		/// 检查用户浏览页面权限
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static bool CheckViewpage(string url) {
			return CheckPermission(url, "viewpage");
		}

		public static List<string> GetPagePermission(string url) {
			Dictionary<string, List<V2_PermissionsModel>> cache = V2_PermissionsCache.GetCache();

			List<string> page_permission = new List<string>();

			if (cache.ContainsKey(url)) {
				List<V2_PermissionsModel> m = cache[url];
				foreach (V2_PermissionsModel v in m) {
					if (CheckPermission(url, v.Permission_key)) {
						page_permission.Add(v.Permission_key);
					}
				}
			}

			return page_permission;
		}
	}
}