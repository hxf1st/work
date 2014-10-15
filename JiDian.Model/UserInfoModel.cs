using System;
using System.Collections.Generic;

namespace JiDian.Model {
	public class UserInfoModel:BaseModel {
		private int _id = 0;
		private int _type = 0;
		private int _status = 0;
		private string _userName = string.Empty;
		private bool _isActive = false;
		private string _account = string.Empty;
		private byte[] _password = null;
		private string _mobile = string.Empty;
		private string _tel = string.Empty;
		private string _email = string.Empty;
		private DateTime _lastLoginTime = DateTime.MinValue;
		private string _remark = string.Empty;

		public int Id {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}
		public int Type {
			get {
				return _type;
			}
			set {
				_type = value;
			}
		}
		public int Status {
			get {
				return _status;
			}
			set {
				_status = value;
			}
		}
		public string UserName {
			get {
				return _userName;
			}
			set {
				_userName = value;
			}
		}
		public bool IsActive {
			get {
				return _isActive;
			}
			set {
				_isActive = value;
			}
		}
		public string Account {
			get {
				return _account;
			}
			set {
				_account = value;
			}
		}
		public byte[] Password {
			get {
				return _password;
			}
			set {
				_password = value;
			}
		}
		public string Mobile {
			get {
				return _mobile;
			}
			set {
				_mobile = value;
			}
		}
		public string Tel {
			get {
				return _tel;
			}
			set {
				_tel = value;
			}
		}
		public string Email {
			get {
				return _email;
			}
			set {
				_email = value;
			}
		}
		public DateTime LastLoginTime {
			get {
				return _lastLoginTime;
			}
			set {
				_lastLoginTime = value;
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
