namespace GenderApp
{
    using GenderApp.Aggregates;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UnityManager
    {
        private static IUnityContainer container = InitializeContainer();

        public static IUnityContainer Container
        {
            get { return container; }
        }

        private static IUnityContainer InitializeContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IGenderRetriever, GenderRetriever>();
            unityContainer.RegisterType<IGenderFormatter, PositiveNegativeIntegerBasedGenderFormatter>();
            unityContainer.RegisterType<IGenderContactsRetriever, GenderContactsRetriever>();
            unityContainer.RegisterInstance<IGenderAggregate>(unityContainer.Resolve<GenderAggregate>());
            return unityContainer;
        }
    }
}
