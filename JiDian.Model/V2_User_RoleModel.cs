using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class V2_User_RoleModel {
		private int _id = 0;
		private int _user_id = 0;
		private int _role_id = 0;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public int User_id {
			get {
				return _user_id;
			}
			set {
				_user_id = value;
			}
		}
		public int Role_id {
			get {
				return _role_id;
			}
			set {
				_role_id = value;
			}
		}
	}
}
