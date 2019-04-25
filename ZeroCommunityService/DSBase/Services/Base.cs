using Base.PublicTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSBase.Services
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public abstract class Base
    {
        #region

        /// <summary>
        /// 异常时触发事件
        /// </summary>
        public event Action<Exception> Exceptioned;

        /// <summary>
        /// 跟踪事件
        /// </summary>
        public event Action<string, string, string> Traced;


        /// <summary>
        /// 构造函数
        /// </summary>
        protected Base()
        {
            
        }

        #endregion


        #region TryCatch

        /// <summary>
        /// TryCatch
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
        /// TryCatch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected T Try<T>(Func<T> func)
        {
            return Try(func, default(T));
        }

        /// <summary>
        /// TryCatch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="fallback">异常时 默认返回值</param>
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

        #region Event
        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="subject">主题</param>
        /// <param name="category">分类</param>
        protected virtual void OnTraced(string message, string subject = null, string category = null)
        {
            var handler = Traced;
            if (handler == null) return;
            handler(message, subject, category);
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="e">异常</param>
        private void OnExceptiond(Exception e)
        {
            NLogTool.ErrorLog(e.Message);
            var handler = Exceptioned;
            if (handler == null) return;
            handler(e);
        }
        #endregion
    }
}
