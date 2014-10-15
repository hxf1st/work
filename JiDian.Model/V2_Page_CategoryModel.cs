using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class V2_Page_CategoryModel {
		private int _id = 0;
		private string _category_name = string.Empty;
		private int _ordernum = 0;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public string Category_name {
			get {
				return _category_name;
			}
			set {
				_category_name = value;
			}
		}
		public int Ordernum {
			get {
				return _ordernum;
			}
			set {
				_ordernum = value;
			}
		}
	}
}
