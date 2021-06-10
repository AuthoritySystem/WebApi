﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace AuthoritySystem.Framework.Extensions
{
    /// <summary>
    /// ServiceCollection扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region 通过反射批量注入指定的程序集

        /// <summary>
        /// 批量注入服务
        /// </summary>
        /// <param name="services">要扩展的类型</param>
        /// <param name="serviceLifetime">服务生命周期，默认scoped</param>
        /// <param name="assemblyNames">程序集数组，无需写.dll扩展名，程序集要添加引用进来</param>
        public static void RegisterService(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, params string[] assemblyNames)
        {
            // 循环遍历程序集数组
            foreach (string assemblyName in assemblyNames)
            {
                foreach (var itemClass in GetClassInterfacePairs(assemblyName))
                {
                    foreach (var itemInterface in itemClass.Value)
                    {
                        // 根据不同的生命周期进行注入
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Transient:
                                services.AddTransient(itemInterface, itemClass.Key);
                                break;
                            case ServiceLifetime.Scoped:
                                services.AddScoped(itemInterface, itemClass.Key);
                                break;
                            case ServiceLifetime.Singleton:
                                services.AddSingleton(itemInterface, itemClass.Key);
                                break;
                        }

                    }
                }
            }
        }
        #endregion


        #region DI依赖注入辅助方法

        /// <summary>
        /// 获取类以及类实现的接口键值对
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns>类以及类实现的接口键值对</returns>
        private static Dictionary<Type, List<Type>> GetClassInterfacePairs(string assemblyName)
        {
            //存储 实现类 以及 对应接口
            Dictionary<Type, List<Type>> dic = new Dictionary<Type, List<Type>>();
            Assembly assembly = GetAssembly(assemblyName);
            if (assembly != null)
            {
                Type[] types = assembly.GetTypes();
                foreach (var item in types.AsEnumerable().Where(x => !x.IsAbstract && !x.IsInterface && !x.IsGenericType))
                {
                    dic.Add(item, item.GetInterfaces().Where(x => !x.IsGenericType).ToList());
                }
            }

            return dic;
        }

        /// <summary>
        /// 获取所有的程序集
        /// </summary>
        /// <returns>程序集集合</returns>
        private static List<Assembly> GetAllAssemblies()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            //var libs = deps.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");//排除所有的系统程序集、Nuget下载包
            var libs = deps.CompileLibraries.Where(lib => lib.Name.StartsWith("AuthoritySystem"));
            foreach (var lib in libs)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    list.Add(assembly);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定的程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns>程序集</returns>
        private static Assembly GetAssembly(string assemblyName)
        {
            return GetAllAssemblies().FirstOrDefault(assembly => assembly.FullName.Contains(assemblyName));
        }

        #endregion
    }
}
