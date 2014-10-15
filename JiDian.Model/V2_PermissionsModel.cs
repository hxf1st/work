using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class V2_PermissionsModel {
		private int _id = 0;
		private int _page_id = 0;
		private string _permission_name = string.Empty;
		private string _permission_key = string.Empty;
		private int _offset = 0;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public int Page_id {
			get {
				return _page_id;
			}
			set {
				_page_id = value;
			}
		}
		public string Permission_name {
			get {
				return _permission_name;
			}
			set {
				_permission_name = value;
			}
		}
		public string Permission_key {
			get {
				return _permission_key;
			}
			set {
				_permission_key = value;
			}
		}
		public int Offset {
			get {
				return _offset;
			}
			set {
				_offset = value;
			}
		}
	}
}
