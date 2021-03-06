﻿using Autofac;
using InterfaceBase.IZCAccount.IData;
using ZCAccountModuleDAL;

namespace Factory.DAL
{
    public class FactoryDAL
    {

        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;



        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
                return container.Resolve<T>();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化
        /// 格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerDependency();
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserDAL>().As<IUserDAL>().InstancePerDependency();
            
            container = builder.Build();
        }
    }
}
