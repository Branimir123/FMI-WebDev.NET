using Ninject.Extensions.Factory;
using Ninject.Modules;
using WebDev.Factories;

namespace WebDev.Project.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Bind<ITopicFactory>().ToFactory().InSingletonScope();
        }
    }
}