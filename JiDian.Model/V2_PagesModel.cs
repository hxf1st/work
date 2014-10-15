using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class V2_PagesModel : BaseModel {
		private int _id = 0;
		private int _category_id = 0;
		private string _page_name = string.Empty;
		private string _url = string.Empty;
		private int _ordernum = 0;
		private int _isnav = 0;
		private string _remark = string.Empty;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public int Category_id {
			get {
				return _category_id;
			}
			set {
				_category_id = value;
			}
		}
		public string Page_name {
			get {
				return _page_name;
			}
			set {
				_page_name = value;
			}
		}
		public string Url {
			get {
				return _url;
			}
			set {
				_url = value;
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
		public int Isnav {
			get {
				return _isnav;
			}
			set {
				_isnav = value;
			}
		}
		public string Remark {
			get {
				return _remark;
			}
			set {
				_remark = value;
			}
		}
	}
}
