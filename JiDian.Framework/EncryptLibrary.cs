using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace JiDian.Framework {

	public class EncryptLibrary {
		private static byte[] cryptKey = new byte[] { 89, 92, 226, 162, 53, 81, 170, 154 };
		private static byte[] cryptIV = new byte[] { 92, 141, 249, 29, 6, 36, 70, 85, 2, 249, 132, 157, 157, 164, 24, 61, 147, 127, 106, 26, 52, 106, 205, 204, 225, 111, 226, 37, 212, 220, 70, 210 };
		/// <summary>
		/// 固定密钥加密
		/// </summary>
		/// <param name="encryptText"></param>
		/// <returns></returns>
		public static string Encrypt(int encryptText) {
			return EncryptString(encryptText.ToString());
		}
		/// <summary>
		/// 固定密钥加密
		/// </summary>
		/// <param name="encryptText"></param>
		/// <returns></returns>
		public static string Encrypt(string encryptText) {
			return EncryptString(encryptText);
		}

		private static string EncryptString(string encryptText) {
			byte[] textBuf = Encoding.UTF8.GetBytes(encryptText.ToString());
			byte[] encryptBuf;
			DES des = new DESCryptoServiceProvider();
			ICryptoTransform encryptor = des.CreateEncryptor(cryptKey, cryptIV);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
			cs.Write(textBuf, 0, textBuf.Length);
			cs.FlushFinalBlock();
			encryptBuf = ms.ToArray();
			cs.Close();
			ms.Close();
			return Convert.ToBase64String(encryptBuf).Replace("+", "%2B").Replace("/", "%2F");
		}
		/// <summary>
		/// 固定密钥解密
		/// </summary>
		/// <param name="decryptText"></param>
		/// <returns></returns>
		public static string Decrypt(string decryptText) {
			try {
				decryptText = decryptText.Replace("%2B", "+").Replace("%2F", "/").Replace(" ", "+");
				byte[] encryptBuf = Convert.FromBase64String(decryptText);
				byte[] decryptBuf = new byte[encryptBuf.Length];
				DES des = new DESCryptoServiceProvider();
				ICryptoTransform decryptor = des.CreateDecryptor(cryptKey, cryptIV);
				MemoryStream ms = new MemoryStream(encryptBuf);
				CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
				int length = cs.Read(decryptBuf, 0, decryptBuf.Length);
				cs.Close();
				ms.Close();
				if (length < encryptBuf.Length) {
					byte[] decryptBuf2 = new byte[length];
					for (int i = 0; i < length; i++) {
						decryptBuf2[i] = decryptBuf[i];
					}
					return Encoding.UTF8.GetString(decryptBuf2);
				}
				else {
					return Encoding.UTF8.GetString(decryptBuf);
				}
			}
			catch {
				throw new Exception("encrypt");
			}
		}
		public static byte[] Md5(string encryptText) {
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(encryptText));
			return result;
		}
		public static bool Equal(byte[] buf1, byte[] buf2) {
			if (Encoding.UTF8.GetString(buf1) == Encoding.UTF8.GetString(buf2)) {
				return true;
			}
			return false;
		}
	}
}
