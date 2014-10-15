using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using JiDian.Model;

namespace JiDian.Framework {
	public class UserData {
		public static int GetUserId() {
			if (HttpContext.Current.User.Identity.IsAuthenticated) {
				return Convert.ToInt32(HttpContext.Current.User.Identity.Name);
			}
			else {
				return 0;
			}
		}

		public static string SetUserData(UserInfoModel model) {
			string userData = model.UserName; //model.Account + "[%,,%]" + 
			return userData;
		}

		public static void SetCookie(UserInfoModel model) {
			string userData = SetUserData(model);
			FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, model.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(120), true, userData);
			HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
			cookie.Value = FormsAuthentication.Encrypt(fat);
			cookie.Expires = fat.Expiration;
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		public static string GetUserName() {
			try {
				FormsAuthenticationTicket fat = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies["jidian"].Value);
				return fat.UserData;
			}
			catch {
				return "";
			}
		}
	}
}
