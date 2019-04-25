using Base.PublicTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DSBase.Data
{
    public abstract class Base
    {
        private const string password = "zxl@1996124";

        protected IDbConnection ZCAccount
        {
            get
            {
                const string name = "ZCAccount";
                const string defaultValue = "server=192.168.199.145;database="+ name + ";uid=sa;pwd=" + password + ";";
                return new SqlConnection(defaultValue);
            }
        }

        #region 异常处理

        /// <summary>
        /// 异常处理
        /// </summary>

        public event Action<Exception> Exceptioned;

        #region TryCatch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                OnExceptiond(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected T Try<T>(Func<T> func)
        {
            return Try(func, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        protected T Try<T>(Func<T> func, T fallback)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                OnExceptiond(e);
                return fallback;
            }
        }

        #endregion

        /// <summary>
        /// 异常处理方法
        /// </summary>
        /// <param name="e">异常</param>
        protected virtual void OnExceptiond(Exception e)
        {
            NLogTool.ErrorLog(e.Message);
            var handler = Exceptioned;
            if (handler == null) return;
            handler(e);
        }

        #endregion

    }
}
