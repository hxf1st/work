using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class V2_RoleModel:BaseModel {
		private int _id = 0;
		private string _role_name = string.Empty;
		private byte[] _permission = null;
		private string _remark = string.Empty;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public string Role_name {
			get {
				return _role_name;
			}
			set {
				_role_name = value;
			}
		}
		public byte[] Permission {
			get {
				return _permission;
			}
			set {
				_permission = value;
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
