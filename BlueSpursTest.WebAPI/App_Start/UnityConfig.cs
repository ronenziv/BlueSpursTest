using Aleph1.DI.Contracts;
using Aleph1.DI.UnityImplementation;
using BlueSpursTest.WebAPI;
using BlueSpursTest.WebAPI.Classes;
using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityConfig), nameof(UnityConfig.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityConfig), nameof(UnityConfig.Shutdown))]

namespace BlueSpursTest.WebAPI
{
    /// <summary>Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.</summary>
    internal static class UnityConfig
    {
        private static IUnityContainer DIContainer { get; set; }

        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            // create an empty container
            DIContainer = new UnityContainer();

            // register all your components with the container here
            ModuleLoader.LoadModulesFromAssemblies(new UnityModuleRegistrar(DIContainer), AppDomain.CurrentDomain.BaseDirectory, SettingsManager.ModulesPath);

            // point the WebAPI to use the container
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(DIContainer);
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            DIContainer.Dispose();
        }
    }
}