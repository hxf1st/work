using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JiDian.Framework;
using JiDian.BLL;
using JiDian.Model;

namespace JiDian.Web.sys {
	public partial class roles : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			VelocityHelper vh = VelocityCreator.Instance();

			V2_RoleBLL bll = new V2_RoleBLL();
			List<V2_RoleModel> list = bll.GetList("1=1");
			bll.Dispose();

			vh.Put("cls", new VelocityFormatter());
			vh.Put("id_prefix", "R");
			vh.Put("data", list);
			vh.Display("roles.html");

		}
	}
}
