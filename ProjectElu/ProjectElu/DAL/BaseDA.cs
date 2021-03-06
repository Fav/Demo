﻿using IBatisNet.DataMapper;
using System.Collections.Generic;

namespace ProjectElu
{
    public static class BaseDA
    {
        public static void Insert<T>(T t) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                object obj = iSqlMapper.Insert(GetNameSpace<T>()+".Insert", t);
            }

        }

        public static int Update<T>(T t) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.Update(GetNameSpace<T>() + ".Update", t);
            }
            return 0;
        }

        public static int Delete(string tableName, object primaryKeyId)
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.Delete(tableName + ".DeleteByName", primaryKeyId);
            }
            return 0;
        }
        public static int Delete<T>(object primaryKeyId) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.Delete( GetNameSpace<T>()+".DeleteById", primaryKeyId);
            }
            return 0;
        }

        public static T Retrive<T>(object primaryKeyId) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForObject<T>(GetNameSpace<T>() + ".SelectByID", primaryKeyId);
            }
            return null;
        }

        public static IList<T> QueryForList<T>(object parameterObject = null,string sqlMethod=null) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                string strMethod =string.IsNullOrEmpty( sqlMethod )? ".query_list" : "." + sqlMethod;
                return iSqlMapper.QueryForList<T>(GetNameSpace<T>() + strMethod, parameterObject);
            }
            return null;
        }
        public static int QueryForCount<T>(object parameterObject = null) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                object obj = iSqlMapper.QueryForObject(GetNameSpace<T>() + ".query_cnt", parameterObject);
                if (obj != null)
                {
                    return (int)obj;
                }
            }
            return 0;
        }
        /// <summary>
        /// 获取命名空间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetNameSpace<T>() where T : class
        {
            string type = typeof(T).ToString();
            int i = type.LastIndexOf('.');
            return type.Substring(i + 1, type.Length - i - 1);
        }
    }
}