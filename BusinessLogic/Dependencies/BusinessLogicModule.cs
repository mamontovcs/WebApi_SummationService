using DataAccess;
using DataAccess.Repositories;
using Ninject;
using Ninject.Modules;

namespace BusinessLogic.Dependencies
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            var repository = new StandardKernel(new DataAccessModule()).Get<ISummationSessionsRepository>();
            Bind<ISummationService>().ToConstructor(x => new SummationService(repository));
        }
    }
}
