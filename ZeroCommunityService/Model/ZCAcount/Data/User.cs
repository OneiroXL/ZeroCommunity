using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ZCAcount.Data
{
    public class User
    {

        public int Id { set; get; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Passcode { set; get; }

    }
}
