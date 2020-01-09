using System.Runtime.CompilerServices;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using Murmur;
namespace TinyUrl.Common
{
    public class HashHelper
    {
        public static string GetMd5(string str)
        {
            var bytes=GetMd5Bytes(str);
            var sb=new StringBuilder(32);
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static byte[] GetMd5Bytes(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("this md5 hash string is require not null");
            }
            var md5=MD5.Create();
            var bytes= md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return bytes;
        }
        public static byte[] GetMurmurHashBytes(string str)
        {
           var hash= MurmurHash.Create32();
           
           var bytes= hash.ComputeHash(Encoding.UTF8.GetBytes(str));
           return bytes;
        }
    }
}