using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiDian.Framework {
	public class IntEncode {
		public string Encode(int val) {
			return this.Encode(val.ToString());
		}

		public string Encode(string str) {
			byte[] buf = Encoding.UTF8.GetBytes(str);
			string returnString = "";
			for (int i = 0; i < buf.Length; i = i + 8) {
				byte[] _buf = new byte[8];
				if (buf.Length < i + 8) {
					Array.Copy(buf, i, _buf, 0, buf.Length % 8);
				}
				else {
					Array.Copy(buf, i, _buf, 0, 8);
				}
				ulong l = BitConverter.ToUInt64(_buf, 0);
				if (l.ToString().Length.ToString().Length == 1) {
					returnString += "0" + l.ToString().Length + l.ToString();
				}
				else {
					returnString += l.ToString().Length + l.ToString();
				}
			}
			return returnString;
		}

		public string Decode(string str) {
			List<byte> list = new List<byte>();
			for (int i = 0; i < str.Length; i++) {
				int head = Convert.ToInt32(str[i].ToString() + str[i + 1].ToString());
				ulong l = Convert.ToUInt64(str.Substring(i + 2, head));
				byte[] buf = BitConverter.GetBytes(l);
				list.AddRange(buf);
				i = i + head + 1;
			}
			byte[] _buf = list.ToArray();
			return Encoding.UTF8.GetString(_buf).TrimEnd('\0');
		}
	}
}
