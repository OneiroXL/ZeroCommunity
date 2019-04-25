using Model.ZCAcount.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBase.IZCAccount.IData
{
    public interface IUserDAL
    {
       List<User> GetUserList();
    }
}
