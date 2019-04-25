using System;
using System.Collections.Generic;
using System.Text;

namespace Base.MainEnum
{
    public class APIEnum
    {
        public enum APIStatusEnum
        {
            /// <summary>
            /// 成功
            /// </summary>
            SUCCESS = 10000,

            /// <summary>
            /// 失败
            /// </summary>
            FAIL = 20000,

            /// <summary>
            /// 错误
            /// </summary>
            ERROR = 30000
        }
    }
}
