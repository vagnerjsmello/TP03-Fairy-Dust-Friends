using FairyDustFriends.Domain;
using FairyDustFriends.Domain.Interfaces.Repositories;
using FairyDustFriends.Domain.Interfaces.Services;
using FairyDustFriends.Data;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyDustFriends.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //container.RegisterSingleton<EntityDataContext>();

            // Business/Domain
            container.Register<IFriendService, FriendService>(Lifestyle.Scoped);            

            // Data
            container.Register<IFriendRepository, FriendStoredProcedureRepository>(Lifestyle.Singleton);
            
            //CommonServiceLocator.SimpleInjectorAdapter             
            //ServiceLocator.SetLocatorProvider(() => container.GetAllInstances());
        }
    }
}
