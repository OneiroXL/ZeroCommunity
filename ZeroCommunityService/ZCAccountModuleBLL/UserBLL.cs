using Factory.DAL;
using InterfaceBase.IZCAccount.IData;
using InterfaceBase.IZCAccount.IServices;
using Model.ZCAcount.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZCAccountModuleBLL
{
    public class UserBLL : DSBase.Services.Base, IUserBLL
    {
        private IUserDAL userDAL = FactoryDAL.Resolve<IUserDAL>();

        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            return Try(()=> 
            {
                return userDAL.GetUserList();
            });
            
        }
        #endregion

    }
}
