using Ninject.Modules;
using WebDev.Services;
using WebDev.Services.Contracts;

namespace WebDev.Project.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>();
            this.Bind<ITopicService>().To<TopicService>();
        }
    }
}