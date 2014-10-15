using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Collections;

namespace JiDian.Web.libs {
	public interface IResponseResult {
		string ToJSON<T>(T obj, int draw,int count);
		string ToJSON<T>(T obj);
	}

	public class ResponseResult: IResponseResult {

		public ResponseResult() {
		}

		public ResponseResult(int statusCode,string msg) {
			this.StatusCode = statusCode;
			this.Msg = msg;
		}

		public int StatusCode { get; set; }
		public string Msg { get; set; }

		#region IResponseResult Members

		public string ToJSON<T>(T obj,int draw,int count) {
			int dataCount = 1;
			if (obj is IList) {
				dataCount = (obj as IList).Count;
			}

			JsonResult<T> result = new JsonResult<T>() {
				StatusCode = this.StatusCode,
				Msg = this.Msg,
				draw = draw,
				recordsTotal = count,
				recordsFiltered = count,
				data = obj
			};

			return JsonConvert.SerializeObject(result);
		}

		public string ToJSON<T>(T obj) {
			JsonModelResult<T> result = new JsonModelResult<T>() {
				StatusCode = this.StatusCode,
				Msg = this.Msg,
				Data = obj
			};

			return JsonConvert.SerializeObject(result);
		}

		#endregion
	}

	public class JsonResult<T> {
		public int StatusCode { get; set; }
		public string Msg { get; set; }
		public int draw { get; set; }
		public int recordsTotal { get; set; }
		public int recordsFiltered { get; set; }
		public T data { get; set; }
	}

	public class JsonModelResult<T> {
		public int StatusCode { get; set; }
		public string Msg { get; set; }
		public T Data { get; set; }
	}

	public class JsonCommonResult {
		public int StatusCode { get; set; }
		public string Msg { get; set; }
	}
}
