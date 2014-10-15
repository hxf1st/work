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
	public partial class pages : Page {
		protected void Page_Load(object sender, EventArgs e) {
			VelocityHelper vh = VelocityCreator.Instance();

			V2_PagesBLL bll = new V2_PagesBLL();
			List<V2_PagesModel> list = bll.GetList("1=1 order by ordernum");
			bll.Dispose();

			vh.Put("cls", new VelocityFormatter());
			vh.Put("data", list);
			vh.Display("pages1.html");
		}
	}
}
