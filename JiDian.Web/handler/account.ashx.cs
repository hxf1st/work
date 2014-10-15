using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JiDian.Web.libs;
using Newtonsoft.Json;
using JiDian.Framework;
using System.Data;
using JiDian.Model;
using JiDian.BLL;

namespace JiDian.Web.handler {
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class account : BaseHandler {

		private const string ID_PREFIX = "U";

		public class UserInfoResult {
			public string id_ex { get; set; }
			public string username { get; set; }
			public string account { get; set; }
			public int is_active { get; set; }
			public int account_type { get; set; }
			public string mobile { get; set; }
			public string email { get; set; }
			public string remark { get; set; }
		}

		public override void Process(HttpContext context, string action) {
			if (action == "load") {
				#region load
				int draw = Convert.ToInt32(context.Request.Form["draw"]);
				int start = Convert.ToInt32(context.Request.Form["start"]);
				int length = Convert.ToInt32(context.Request.Form["length"]);

				Pagination pagination = new Pagination(length);
				DataTable dt = null;
				int count = 0;
				int pageIndex = pagination.CalcPageIndex(start);
				dt = pagination.GetPageData("v2_pages", "*", "id", pagination.PageSize, pageIndex, 0, "", out count);
				List<V2_PagesModel> li = Helper.ConvertDataTableToListWithEncrypt<V2_PagesModel>(dt, "P");

				ResponseResult result = new ResponseResult();
				result.StatusCode = 200;
				result.Msg = "success";
				context.Response.Write(result.ToJSON<List<V2_PagesModel>>(li, draw, count));
				#endregion
			}
			else if (action == "info") {
				#region
				string idstr = context.Request.QueryString["id"];
				int id = Helper.Id_Decode(idstr, ID_PREFIX);
				UserInfoBLL bll = new UserInfoBLL();
				UserInfoModel model = bll.GetModel(id);
				bll.Dispose();

				UserInfoResult data = new UserInfoResult() {
					id_ex = Helper.Id_Encode(model.Id, ID_PREFIX),
					username = model.UserName,
					account = model.Account,
					account_type = model.Type,
					is_active = model.IsActive ? 1 : 0,
					mobile = model.Mobile,
					email = model.Email,
					remark = model.Remark
				};

				ResponseResult result = new ResponseResult();
				result.StatusCode = 200;
				result.Msg = "success";
				context.Response.Write(result.ToJSON<UserInfoResult>(data));
				#endregion
			}
			else if (action == "save") {
				#region
				string data_id = context.Request.Form["data_id"];
				string userName = context.Request.Form["userName"];
				string account = context.Request.Form["account"];
				bool isActive = Convert.ToInt32(context.Request.Form["isActive"]) == 1 ? true : false;
				int type = Convert.ToInt32(context.Request.Form["type"]);
				string mobile = context.Request.Form["mobile"];
				string email = context.Request.Form["email"];
				string remark = context.Request.Form["remark"];


				UserInfoBLL bll = new UserInfoBLL();

				if (bll.ExistsWithLogicKey(account.Trim())) {

					bll.Dispose();

					JsonCommonResult result = new JsonCommonResult();
					result.StatusCode = 200;
					result.Msg = "exists";
					context.Response.Write(JsonConvert.SerializeObject(result));
				}
				else {

					int _id = Helper.Id_Decode(data_id, ID_PREFIX);
					UserInfoModel model = bll.GetModel(_id);
					bool exists = true;
					if (model == null) {
						model = new UserInfoModel();
						model.Password = EncryptLibrary.Md5("123456");
						model.Status = 1;
						exists = false;
					}
					model.UserName = userName;
					model.Account = account;
					model.IsActive = isActive;
					model.Type = type;
					model.Mobile = mobile;
					model.Email = email;
					model.Remark = remark;

					if (exists) bll.UpdateRow(model);
					else bll.AddRow(model);

					bll.Dispose();


					JsonCommonResult result = new JsonCommonResult();
					result.StatusCode = 200;
					result.Msg = "success";
					context.Response.Write(JsonConvert.SerializeObject(result));
				}
				#endregion
			}
		}
	}
}
