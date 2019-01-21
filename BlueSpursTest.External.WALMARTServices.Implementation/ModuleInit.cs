using Aleph1.DI.Contracts;
using BlueSpursTest.External.Services.Contracts;
using System.ComponentModel.Composition;

namespace BlueSpursTest.External.WALMARTServices.Implementation
{
    /// <summary>Used to register concrete implemtations to the DI container</summary>
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        /// <summary>Used to register concrete implemtations to the DI container</summary>
        /// <param name="registrar">add implementation to the DI container using this registrar</param>
        public void Initialize(IModuleRegistrar registrar)
        {
            //You can register as many types as you want into the Container

            registrar.RegisterTypeAsSingelton<IExternalProductService, WALMARTProductService>("Walmart");
            registrar.RegisterTypeAsSingelton<IExternalProductService, WALMARTProductService>();
        }
    }
}
