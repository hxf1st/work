using System;
using System.Collections.Generic;
using System.Text;
using JiDian.Model;
using JiDian.BLL;

namespace JiDian.Framework.Cache {
	public class V2_PageCategoryCache {
		private static List<V2_Page_CategoryModel> list;

		public static List<V2_Page_CategoryModel> GetCache() {
			if (list == null) {
				UpdateCache();
			}
			return list;
		}

		private static void UpdateCache() {
			list = new List<V2_Page_CategoryModel>();

			V2_Page_CategoryBLL bll = new V2_Page_CategoryBLL();
			try {
				list = bll.GetList("1=1 order by ordernum");
			}
			catch {
			}
			finally {
				bll.Dispose();
			}
		}

		public static void ClearCache() {
			list = null;
		}
	}
}
