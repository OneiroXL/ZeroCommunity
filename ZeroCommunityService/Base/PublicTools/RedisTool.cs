using Base.Map;
using Base.PublicTools.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Base.MainEnum.RedisEnum;

namespace Base.PublicTools
{
    public class RedisTool
    {

        #region String
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <param name="t">数据</param>
        /// <param name="dt">保存时间</param>
        /// <returns></returns>
        public static bool Set<T>(RedisKeyEnum keyEnum, string key, T t, TimeSpan dt)
        {
            string setKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(setKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                string json = JsonConvert.SerializeObject(t);
                return redis.StringSet(setKey, json, dt);
            }
            return false;
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <returns></returns>
        public static T Get<T>(RedisKeyEnum keyEnum, string key)
        {
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                string db = redis.StringGet(getKey);
                if (string.IsNullOrEmpty(db))
                {
                    return default(T);
                }
                return JsonConvert.DeserializeObject<T>(db);

            }
            return default(T);
        }

        #endregion

        #region List

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <param name="t">数据</param>
        /// <param name="dt">保存时间</param>
        /// <returns></returns>
        public static long SetList<T>(RedisKeyEnum keyEnum, string key, T t, TimeSpan dt)
        {
            string setKey = RedisMap.GetRedisKey(keyEnum, key);
            if (string.IsNullOrEmpty(setKey)) return 0;

            int index = GetDBIndex(keyEnum);
            RedisBaseTool redis = new RedisBaseTool(index);
            string json = JsonConvert.SerializeObject(t);
            return redis.ListLeftPush(setKey, json);
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <returns></returns>
        public static List<T> GetList<T>(RedisKeyEnum keyEnum, string key)
        {
            List<T> result = new List<T>();
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                var db = redis.ListRange(getKey);
                if (db == null)
                {
                    return result;
                }
                foreach (var item in db)
                {
                    var model = JsonConvert.DeserializeObject<T>(item);
                    result.Add(model);
                }
            }
            return result;
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        public static List<T> GetList<T>(RedisKeyEnum keyEnum, string key, int page, int pageSize)
        {
            List<T> result = new List<T>();
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);

                page = page < 0 ? 1 : page;
                pageSize = pageSize < 0 ? 10 : pageSize;
                int startRow = (page - 1) * pageSize;
                int endRow = page * pageSize - 1;

                var db = redis.ListRange(getKey, startRow, endRow);
                if (db == null)
                {
                    return result;
                }
                foreach (var item in db)
                {
                    var model = JsonConvert.DeserializeObject<T>(item);
                    result.Add(model);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取列表总长度
        /// </summary>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <returns></returns>
        public static int GetListLength(RedisKeyEnum keyEnum, string key)
        {
            int result = 0;
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                long totalCount = redis.ListLength(getKey);
                result = Convert.ToInt32(totalCount);
            }
            return result;
        }
        #endregion

        #region Key

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <returns></returns>
        public static bool Remove(RedisKeyEnum keyEnum, string key)
        {
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {
                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                return redis.KeyDelete(getKey);
            }
            return false;
        }

        /// <summary>
        /// 是否存在当前KEY值
        /// </summary>
        /// <param name="keyEnum">缓存枚举</param>
        /// <param name="key">变量参数</param>
        /// <returns></returns>
        public static bool IsHaveKey(RedisKeyEnum keyEnum, string key)
        {
            string getKey = RedisMap.GetRedisKey(keyEnum, key);
            if (!string.IsNullOrEmpty(getKey))
            {

                int index = GetDBIndex(keyEnum);
                RedisBaseTool redis = new RedisBaseTool(index);
                return redis.KeyExists(getKey);
            }
            return false;
        }

        /// <summary>
        /// 获取所有Key
        /// </summary>
        /// <param name="keyPreFix"></param>
        /// <returns></returns>
        public static List<string> GetAllKeys(string keyPreFix)
        {
            RedisBaseTool redis = new RedisBaseTool(1);
            return redis.GetAllKeys(keyPreFix);
        }

        /// <summary>
        /// 设定存放位置
        /// </summary>
        /// <param name="keyEnum"></param>
        /// <returns></returns>
        private static int GetDBIndex(RedisKeyEnum keyEnum)
        {
            int dbIndex = 0;
            switch ((int)keyEnum)
            {
                case 2: dbIndex = 1; break;
                case 4: dbIndex = 3; break;
                case 7: dbIndex = 4; break;
                case 8: dbIndex = 5; break;
                case 9: dbIndex = 6; break;
                case 10: dbIndex = 7; break;
                case 11: dbIndex = 8; break;
                case 12: dbIndex = 9; break;
                case 13: dbIndex = 10; break;
            }
            return dbIndex;
        }

        #endregion

    }
}
