using Ninject.Modules;
using Ninject.Web.Common;
using PhotoLife.Data;
using WebDev.Data;
using WebDev.Data.Contracts;

namespace WebDev.Project.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWebDevEntities>().To<WebDevEntities>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}