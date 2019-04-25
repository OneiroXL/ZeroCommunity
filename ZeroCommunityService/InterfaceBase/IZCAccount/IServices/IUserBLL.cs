using Model.ZCAcount.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBase.IZCAccount.IServices
{
    public interface IUserBLL
    {
        List<User> GetUserList();
    }
}
