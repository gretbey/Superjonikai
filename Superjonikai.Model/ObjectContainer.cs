using Superjonikai.Model.Services;
using SimpleInjector;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System.Linq;
using System.IO;
using System;
using System.Reflection;

namespace Superjonikai.Model
{
    public class ObjectContainer
    {
        public static void InitializeContainer(Container container, string[] pluginsPaths)
        {
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<IFlowersCatalogService, FlowersCatalogService>(Lifestyle.Scoped);
            container.Register<IBouquetsService, BouquetsService>(Lifestyle.Scoped);
            container.Register<IRegistrationService, RegistrationService>(Lifestyle.Scoped);
            container.Register<IGiftCardService, GiftCardService>(Lifestyle.Scoped);
            container.Register<IOrderService, OrderService>(Lifestyle.Scoped);

            if(pluginsPaths[0] != "")
            {
                InitializePlugins<OrderService>(container, "Service", pluginsPaths[0], Lifestyle.Scoped);
            }

            if(pluginsPaths[1] != "")
            {
                InitializePlugins<IOrderRepository>(container, "Repository", pluginsPaths[1], Lifestyle.Scoped);
            }
        }

         
        private static void InitializePlugins<T>(Container container, string endOfClass, string pluginsPath, Lifestyle lifestyle)
        {

            var assembliesTypes = typeof(T).Assembly.GetExportedTypes();
            var pluginsDirectoryFiles = new DirectoryInfo(pluginsPath).GetFiles();

            try
            {
                var abstractions = (
                    from type in assembliesTypes
                    where type.IsInterface
                    where type.Name.EndsWith(endOfClass)
                    select type).ToArray();

                var pluginAssemblies =
                    from file in pluginsDirectoryFiles
                    where file.Extension.ToLower() == ".dll"
                    select Assembly.LoadFrom(file.FullName);

                var implementationTypes =
                    from assembly in pluginAssemblies
                    from type in assembly.GetExportedTypes()
                    where abstractions.Any(r => r.IsAssignableFrom(type))
                    where !type.IsAbstract
                    where !type.IsGenericTypeDefinition
                    select type;

                foreach (var type in implementationTypes)
                {
                    var abstraction = abstractions.Single(r => r.IsAssignableFrom(type));
                    container.Register(abstraction, type, lifestyle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Injection from DLL failed.");
            }
            
        }


    }
}
