using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JiDian.BLL;
using JiDian.Model;
using JiDian.Web.libs;
using System.Data;
using JiDian.Framework;
using Newtonsoft.Json;

namespace JiDian.Web.handler {
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class pages : BaseHandler {

		public override void Process(HttpContext context,string action) {
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
				int id = Helper.Id_Decode(idstr, "P");
				V2_PagesBLL bll = new V2_PagesBLL();
				V2_PagesModel model = bll.GetModel(id);
				model.Id_Ex = Helper.Id_Encode(model.Id, "P");
				bll.Dispose();

				ResponseResult result = new ResponseResult();
				result.StatusCode = 200;
				result.Msg = "success";
				context.Response.Write(result.ToJSON<V2_PagesModel>(model));
				#endregion
			}
			else if (action == "save") {
				#region
				string page_id = context.Request.Form["page_id"];
				int pagecategory = Convert.ToInt32(context.Request.Form["pagecategory"]);
				string pagename = context.Request.Form["pagename"];
				string url = context.Request.Form["url"];
				int ordernum = Convert.ToInt32(context.Request.Form["ordernum"]);
				int isnav = Convert.ToInt32(context.Request.Form["isnav"]);
				string remark = context.Request.Form["remark"];

				int p_id = Helper.Id_Decode(page_id, "P");

				V2_PagesBLL bll = new V2_PagesBLL();
				V2_PagesModel model = bll.GetModel(p_id);
				bool exists = true;
				if (model == null) {
					model = new V2_PagesModel();
					exists = false;
				}
				model.Category_id = pagecategory;
				model.Page_name = pagename;
				model.Url = url;
				model.Ordernum = ordernum;
				model.Isnav = isnav;
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
