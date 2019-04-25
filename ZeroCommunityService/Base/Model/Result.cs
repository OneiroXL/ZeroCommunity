using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Model
{
    public class Result
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 状态信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 简单状态类
        /// </summary>
        public Result()
        {

        }

        /// <summary>
        /// 简单状态类
        /// </summary>
        /// <param name="status">状态</param>
        public Result(int status)
            : this(status, string.Empty)
        {

        }

        /// <summary>
        /// 简单状态类
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">状态信息</param>
        public Result(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }

    /// <summary>
    /// 简单状态泛型类
    /// </summary>
    /// <typeparam name="T">泛型数据类型</typeparam>
    public class Result<T> : Result
    {
        public T Data { get; set; }

        public Result()
        {

        }

        public Result(int status)
            : this(status, default(T), string.Empty)
        {
        }

        public Result(int status, string messge)
            : this(status, default(T), messge)
        {
        }

        public Result(int status, T data)
            : this(status, data, string.Empty)
        {
        }

        public Result(int status, T data, string message)
            : base(status, message)
        {
            Data = data;
        }
    }
    public class ResultPage<T> : Result
    {
        public T Data { get; set; }
        public int Total { set; get; }

        public ResultPage()
        {

        }

        public ResultPage(int status)
            : this(status, default(T), string.Empty)
        {
        }

        public ResultPage(int status, string messge)
            : this(status, default(T), messge)
        {
        }

        public ResultPage(int status, T data)
            : this(status, data, string.Empty)
        {
        }

        public ResultPage(int status, T data, string message)
            : base(status, message)
        {
            Data = data;
        }
    }
}
