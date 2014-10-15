using System;
using System.Collections.Generic;
using System.Text;
using JiDian.Framework.Cache;

namespace JiDian.Framework.Cache {
	public class V2_ClearPowerCache {
		public static void Clear() {
			V2_PageCategoryCache.ClearCache();
			V2_PagesCache.ClearCache();
			V2_PermissionsCache.ClearCache();
			V2_RoleCache.ClearCache();
			V2_UserPermissionCache.ClearCache();
			V2_UserRoleCache.ClearCache();
		}
	}
}
