using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JiDian.Framework;

namespace JiDian.Web.handler {

	interface IHandler {
		bool CheckPermission(string url, string action);
	}


	public class BaseHandler : IHttpHandler, IHandler {

		public void ProcessRequest(HttpContext context) {

			#region url and action
			string url = "";
			if (context.Request.ApplicationPath == "/") {
				url = context.Request.UrlReferrer.AbsolutePath.ToLower();
			}
			else {
				url = context.Request.UrlReferrer.AbsolutePath.Substring(context.Request.ApplicationPath.Length).ToLower();
			}

			string action = context.Request.QueryString["action"].ToLower() ?? "";
			#endregion

			//if (CheckPermission(url, action)) {
			//  Process(context, action);
			//}
			//else {
			//  context.Response.Write("access denied");
			//}

			Process(context, action);
		}

		public virtual void Process(HttpContext context, string action) {
			throw new Exception(action);
		}

		public bool IsReusable {
			get {
				return false;
			}
		}


		#region IHandler Members

		public bool CheckPermission(string url, string action) {
			return Permission.CheckPermission(url, action);
		}

		#endregion
	}
}
