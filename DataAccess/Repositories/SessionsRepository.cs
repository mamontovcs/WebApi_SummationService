using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    /// <summary>
    /// The Repository mediates between the domain and 
    /// data mapping layers, acting like an in-memory collection of domain objects
    /// Implements <see cref="ISessionsRepository"/> interface
    /// </summary>
    internal class SessionsRepository : ISessionsRepository
    {
        /// <summary>
        /// Represents a combination of the Unit Of Work and Repository
        /// patterns such that it can be used to query from a database and group together
        /// changes that will then be written back to the store as a unit. 
        /// </summary>
        private readonly DatabaseContext _databaseContext;

        /// <summary>
        /// Represents the collection of all <see cref="ISession"/> 
        /// entities in the context
        /// </summary>
        private readonly DbSet<ISession> _sessions;

        /// <summary>
        /// Creates instance of <see cref="SessionsRepository"/>
        /// </summary>
        /// <param name="databaseContext">Database context</param>
        public SessionsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            _sessions = _databaseContext.Set<ISession>();
        }

        /// <summary>
        /// Adds <see cref="ISession"/> item to the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/>Session to add</param>
        public void Create(ISession session)
        {
            _sessions.Add(session);
        }

        /// <summary>
        /// Finds <see cref="ISession"/> item in the corresponding
        /// <see cref="DatabaseContext"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="ISession"/>Found object</returns>
        public ISession FindById(int id)
        {
            return _sessions.Find(id);
        }

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>All <see cref="ISession"/> Objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public IEnumerable<ISession> Get()
        {
            return _sessions.AsNoTracking().ToList();
        }

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="ISession"/> objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public IEnumerable<ISession> Get(Func<ISession, bool> predicate)
        {
            return _sessions.AsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// Gets first corresponding object by 
        /// predicate from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>Founded <see cref="ISession"/> object 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public ISession GetOne(Func<ISession, bool> predicate)
        {
            return _sessions.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Removes <see cref="ISession"/> 
        /// item from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/> item to remove</param>
        public void Remove(ISession session)
        {
            try
            {
                _sessions.Remove(session);
            }
            catch (ArgumentNullException)
            {

            }
        }

        /// <summary>
        /// Updates <see cref="ISession"/> item in the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/> item to update</param>
        public void Update(ISession session)
        {
            _databaseContext.Entry(session).State = EntityState.Modified;
        }
    }
}
