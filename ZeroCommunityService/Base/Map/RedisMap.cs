using System;
using System.Collections.Generic;
using System.Text;
using static Base.MainEnum.RedisEnum;

namespace Base.Map
{
    public class RedisMap
    {
        #region Redis-Key管理
        /// <summary>
        /// Redis-Key管理
        /// </summary>
        /// <param name="key">缓存枚举</param>
        /// <param name="param">变量值</param>
        public static string GetRedisKey(RedisKeyEnum keyEnum, string param)
        {
            string key = string.Empty;
            switch ((int)keyEnum)
            {
                case 1: key = "MonitorIP_" + param; break;
                
            }
            return key;
        }
        #endregion
    }
}
