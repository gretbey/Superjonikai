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
        public static void InitializeContainer(Container container)
        {
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<IFlowersCatalogService, FlowersCatalogService>(Lifestyle.Scoped);
            container.Register<IBouquetsService, BouquetsService>(Lifestyle.Scoped);
            //InitializePlugins<IFlowerRepository>(container, "Repository", pluginsDllPaths[1], Lifestyle.Scoped);
        }

        private static void InitializePlugins<T>(Container container, string classNameEndsWith,
            string pluginsDirectoryPath, Lifestyle lifestyle)
        {
            if (pluginsDirectoryPath != "")
            {
                try
                {
                    var abstractions = (
                        from type in typeof(T).Assembly.GetExportedTypes()
                        where type.IsInterface
                        where type.Name.EndsWith(classNameEndsWith)
                        select type).ToArray();

                    var pluginAssemblies =
                        from file in new DirectoryInfo(pluginsDirectoryPath).GetFiles()
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
                }
            }
        }
    }
}
