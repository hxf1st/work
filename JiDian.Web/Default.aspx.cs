using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JiDian.Framework;
using System.Web.Security;
using JiDian.BLL;
using JiDian.Model;

namespace JiDian.Web {
	public partial class _Default : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				if (!string.IsNullOrEmpty(Request.QueryString["qut"])) {
					FormsAuthentication.SignOut();
				}
			}
		}

		protected void btn_click(object sender, EventArgs e) {
			string account = this.account.Value.Trim();
			string password = this.pwd.Value.Trim();
			string code = this.code.Value.Trim();

			if (Session["CheckCode"] == null) {
				this.login_error.Text = "验证码过期失效，请重新输入验证码";
				return;
			}

			if (code.ToLower() != Session["CheckCode"].ToString()) {
				this.login_error.Text = "验证码输入错误";
				return;
			}


			UserInfoBLL bll = new UserInfoBLL();

			try {
				UserInfoModel model = bll.GetModelWithLogicKey(account);
				if (model != null) {
					if (model.IsActive) {
						if (EncryptLibrary.Equal(model.Password, EncryptLibrary.Md5(password))) {
							model.LastLoginTime = DateTime.Now;
							bll.UpdateRow(model);
							bll.Dispose();

							UserData.SetCookie(model);

							Response.Redirect("main.aspx");
						}
					}
				}
				this.login_error.Text = "用户名不存在或密码错误";
			}
			finally {
				bll.Dispose();
			}
		}
	}
}
