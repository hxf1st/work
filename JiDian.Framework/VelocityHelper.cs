using System;
using System.Web;
using System.IO;

using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using NVelocity.Runtime;
using Commons.Collections;
using System.Collections.Generic;

namespace JiDian.Framework {
	/// <summary>
	/// NVelocity模板工具类 VelocityHelper
	/// </summary>
	public class VelocityHelper {
		private VelocityEngine velocity = null;
		private IContext context = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="templatDir">模板文件夹路径</param>
		public VelocityHelper(string templatDir) {
			Init(templatDir);
		}
		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public VelocityHelper() { ;}
		/// <summary>
		/// 初始话NVelocity模块
		/// </summary>
		/// <param name="templatDir">模板文件夹路径</param>
		public void Init(string templatDir) {
			//创建VelocityEngine实例对象
			velocity = new VelocityEngine();

			//使用设置初始化VelocityEngine
			ExtendedProperties props = new ExtendedProperties();
			props.AddProperty(RuntimeConstants.RESOURCE_LOADER, "file");
			props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, templatDir);
			props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_CACHE, true);
			props.AddProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
			props.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");
			velocity.Init(props);

			//为模板变量赋值
			context = new VelocityContext();
		}
		/// <summary>
		/// 给模板变量赋值
		/// </summary>
		/// <param name="key">模板变量</param>
		/// <param name="value">模板变量值</param>
		public void Put(string key, object value) {
			if (context == null)
				context = new VelocityContext();
			context.Put(key, value);
		}

		public void Clear() {
			string[] keys = new string[20];
			context.Keys.CopyTo(keys, 0);
			foreach (string key in keys) {
				context.Remove(key);
			}
			keys = null;
		}

		/// <summary>
		/// 显示模板
		/// </summary>
		/// <param name="templatFileName">模板文件名</param>
		public void Display(string templatFileName) {
			//从文件中读取模板
			Template template = velocity.GetTemplate(templatFileName);
			//合并模板
			StringWriter writer = new StringWriter();
			template.Merge(context, writer);
			//输出
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write(writer.ToString());
			HttpContext.Current.Response.Flush();
			HttpContext.Current.Response.End();
		}

		public string Render(string templateFileName) {
			Template template = velocity.GetTemplate(templateFileName);
			//合并模板
			StringWriter writer = new StringWriter();
			template.Merge(context, writer);
			//输出
			writer.Flush();
			return writer.ToString();
		}
	}

	public class VelocityFormatter {
		public VelocityFormatter() {
		}

		public string sub_str(string str, int len) {
			if (str.Length >= len)
				return str.Substring(0, len);
			else
				return str;
		}

		public string int_encode(int value, string prefix) {
			return int_encode(prefix + "_" + value.ToString());
		}

		public string int_encode(int val) {
			IntEncode e = new IntEncode();
			return e.Encode(val.ToString());
		}

		public string int_encode(string val) {
			IntEncode e = new IntEncode();
			return e.Encode(val);
		}

		public int to_int(string val) {
			int r = 0;
			int.TryParse(val, out r);
			return r;
		}
	}

	public class VelocityCreator {
		private static VelocityHelper _instance = null;
		private static string path = HttpContext.Current.Server.MapPath("~/templates");

		public static VelocityHelper Instance() {
			if (_instance == null) {
				InitVelocity();
			}
			_instance.Clear();
			return _instance;
		}

		private static void InitVelocity() {
			_instance = new VelocityHelper();
			_instance.Init(path);
		}

	}

}