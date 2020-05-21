using DataAccess.Models;
using System.Data.Entity;

namespace DataAccess
{
    /// <summary>
    /// Represents a combination of the Unit Of Work and Repository
    /// patterns such that it can be used to query from a database and group together
    /// changes that will then be written back to the store as a unit. 
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Creates instance of <see cref="DatabaseContext"/>
        /// </summary>
        public DatabaseContext() 
            : base("name=SummationDatabase")
        {

        }

        /// <summary>
        /// Represents the collection of all <see cref="ISession"/> 
        /// entities in the context
        /// </summary>
        public DbSet<ISession> Sessions { get; set; }
    }
}
