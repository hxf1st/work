using System;
using System.Collections.Generic;
using System.Text;
using JiDian.Model;
using JiDian.BLL;

namespace JiDian.Framework.Cache {
	public class V2_PagesCache {
		private static Dictionary<int, List<V2_PagesModel>> dict;

		public static Dictionary<int, List<V2_PagesModel>> GetCache() {
			if (dict == null) {
				UpdateCache();
			}
			return dict;
		}

		private static void UpdateCache() {
			dict = new Dictionary<int, List<V2_PagesModel>>();

			V2_Page_CategoryBLL cbll = new V2_Page_CategoryBLL();
			List<V2_Page_CategoryModel> clist = cbll.GetList();

			V2_PagesBLL bll = new V2_PagesBLL();
			foreach (V2_Page_CategoryModel cmodel in clist) {
				List<V2_PagesModel> list = bll.GetList("category_id=" + cmodel.Id + " order by ordernum");

				if (!dict.ContainsKey(cmodel.Id)) {
					dict.Add(cmodel.Id, list);
				}
			}

			cbll.Dispose();
			bll.Dispose();
		}

		public static void ClearCache() {
			dict = null;
		}
	}
}
