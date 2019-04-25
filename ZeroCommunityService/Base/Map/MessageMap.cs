using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Map
{
    public class MessageMap
    {

        #region 获取消息
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string GetMessage(int v)
        {
            switch (v)
            {
                case 10000: { return "成功"; }
                case 10001: { return "你是谁˙︿˙，我不认识你"; }
                case 10002: { return "票都没有，还想进！"; }
                default: { return ""; }
            }
        }
        #endregion


    }
}
