using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectElu
{
   public static class CommonMethod
    {
       public static USER g_User= null;
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }

        public static string GetID()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        
        }
        /// <summary>
        /// 查询参数处理方法，在查询时，用户可能输入一些特殊字符等，通过该方法将其过滤掉
        /// 现在主要是将查询参数类型为String的字符串中'替换为''，因为'在SQL语句中是作为字
        /// 符串的起始和结束符号的，如果作为查询条件，需要转义后才能使用
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public static IDictionary<string, object> PrepareQuery(IDictionary<string, object> map)
        {
            if (map == null)
            {
                return null;
            }
            IDictionary<string, object> newMap = new Dictionary<string, object>(map);

            if (newMap != null)
            {
                foreach (string key in newMap.Keys)
                {
                    object obj = newMap[key];
                    if (obj == null) continue;

                    if (obj.GetType() == typeof(String))
                    {
                        string value = (string)obj;
                        map[key] = value.Replace("'", "''");// 替换单撇号'
                    }
                }
            }

            return map;
        }
    }
}
