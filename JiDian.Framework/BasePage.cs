using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace JiDian.Framework {
	public class BasePage : Page {

		protected override void OnPreInit(EventArgs e) {

			if (!Permission.CheckViewpage(CurrentURL)) {
				Response.Write("access denied");
				Response.Flush();
				Response.End();
			}

			base.OnPreInit(e);
		}

		public string CurrentURL {
			get {
				if (Request.ApplicationPath == "/") {
					return Request.Url.AbsolutePath.ToLower();
				}
				else {
					return Request.Url.AbsolutePath.Substring(Request.ApplicationPath.Length).ToLower();
				}
			}
		}
	}
}
