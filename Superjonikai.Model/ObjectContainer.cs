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
            container.Register<IRegistrationService, RegistrationService>(Lifestyle.Scoped);
            container.Register<IGiftCardService, GiftCardService>(Lifestyle.Scoped);
            container.Register<IOrderService, OrderService>(Lifestyle.Scoped);
        }
    }
}
