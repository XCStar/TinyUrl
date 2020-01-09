using System;
using System.Collections.Generic;

namespace TinyUrl.Common
{
    public class StringHelper
    {
        public static readonly string chars="aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789"; 
        public static string ConvertTo62(byte[] bytes)
        {
            var id=BitConverter.ToUInt32(bytes,0);
            var list=new List<char>();
            while(id>0)
            {
                var item=(int)(id%62);
                list.Add(chars[item]);
                id=id/62;
            }
            list.Reverse();
            return new string(list.ToArray());
        }
    }
}