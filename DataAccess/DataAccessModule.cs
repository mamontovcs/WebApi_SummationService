using DataAccess.Repositories;
using Ninject.Modules;

namespace DataAccess
{
    /// <summary>
    /// A loadable unit that defines bindings for your application.
    /// </summary>
    public class DataAccessModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            var context = new DatabaseContext();

            Bind<ISummationSessionsRepository>().ToConstructor(x => new SummationSessionsRepository(context));
        }
    }
}
