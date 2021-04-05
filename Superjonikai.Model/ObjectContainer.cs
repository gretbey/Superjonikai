using Superjonikai.Model.Services;
using SimpleInjector;

namespace Superjonikai.Model
{
    public class ObjectContainer
    {
        public static void InitializeContainer(Container container)
        {
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
        }
    }
}
