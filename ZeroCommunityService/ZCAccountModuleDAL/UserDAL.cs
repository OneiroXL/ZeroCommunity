using Dapper;
using DSBase.Data.Help;
using InterfaceBase.IZCAccount.IData;
using Model.ZCAcount.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAccountModuleDAL
{
    public class UserDAL : DSBase.Data.Base, IUserDAL
    {
        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            return Try(() =>
            {
                var cmd = SqlBuilder.Select("*")
                          .From("[User]")
                          .ToCommand();
                return ZCAccount.Query<User>(cmd).ToList();
            });
        }

        #endregion

    }
}
