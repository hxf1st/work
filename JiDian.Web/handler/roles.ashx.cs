using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JiDian.Model;
using JiDian.BLL;
using JiDian.Web.libs;
using Newtonsoft.Json;
using System.Web.Services;

namespace JiDian.Web.handler {
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class roles : BaseHandler {

		private const string ID_PREFIX = "R";

		public override void Process(HttpContext context, string action) {
			if (action == "info") {
				#region
				string idstr = context.Request.QueryString["id"];
				int id = Helper.Id_Decode(idstr, ID_PREFIX);
				V2_RoleBLL bll = new V2_RoleBLL();
				V2_RoleModel model = bll.GetModel(id);
				model.Id_Ex = Helper.Id_Encode(model.Id, ID_PREFIX);
				bll.Dispose();

				ResponseResult result = new ResponseResult();
				result.StatusCode = 200;
				result.Msg = "success";
				context.Response.Write(result.ToJSON<V2_RoleModel>(model));
				#endregion
			}
			else if (action == "save") {
				#region
				string data_id = context.Request.Form["data_id"];
				string rolename = context.Request.Form["rolename"];
				string remark = context.Request.Form["remark"];


				int _id = Helper.Id_Decode(data_id, ID_PREFIX);
				V2_RoleBLL bll = new V2_RoleBLL();
				V2_RoleModel model = bll.GetModel(_id);
				bool exists = true;
				if (model == null) {
					model = new V2_RoleModel();
					model.Permission = new byte[4000];
					exists = false;
				}
				model.Role_name = rolename;
				model.Remark = remark;

				if (exists) bll.UpdateRow(model);
				else bll.AddRow(model);

				bll.Dispose();

				JsonCommonResult result = new JsonCommonResult();
				result.StatusCode = 200;
				result.Msg = "success";
				context.Response.Write(JsonConvert.SerializeObject(result));
				#endregion
			}

		}
	}
}
