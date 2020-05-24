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
    /// Implements <see cref="ISummationSessionsRepository"/> interface
    /// </summary>
    internal class SummationSessionsRepository : ISummationSessionsRepository
    {
        /// <summary>
        /// Represents a combination of the Unit Of Work and Repository
        /// patterns such that it can be used to query from a database and group together
        /// changes that will then be written back to the store as a unit. 
        /// </summary>
        private readonly DatabaseContext _databaseContext;

        /// <summary>
        /// Represents the collection of all <see cref="SummationSession"/> 
        /// entities in the context
        /// </summary>
        private readonly DbSet<SummationSession> _sessions;

        /// <summary>
        /// Creates instance of <see cref="SummationSessionsRepository"/>
        /// </summary>
        /// <param name="databaseContext">Database context</param>
        public SummationSessionsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            _sessions = _databaseContext.Set<SummationSession>();
        }

        /// <summary>
        /// Adds <see cref="SummationSession"/> item to the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="SummationSession"/>Session to add</param>
        public void Create(SummationSession session)
        {
            _sessions.Add(session);
            SaveChanges();
        }

        /// <summary>
        /// Finds <see cref="SummationSession"/> item in the corresponding
        /// <see cref="DatabaseContext"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="SummationSession"/>Found object</returns>
        public SummationSession FindById(int id)
        {
            return _sessions.Find(id);
        }

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>All <see cref="SummationSession"/> Objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public IEnumerable<SummationSession> Get()
        {
            return _sessions.AsNoTracking().ToList();
        }

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="SummationSession"/> objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public IEnumerable<SummationSession> Get(Func<SummationSession, bool> predicate)
        {
            return _sessions.AsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// Gets first corresponding object by 
        /// predicate from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>Founded <see cref="SummationSession"/> object 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        public SummationSession GetOne(Func<SummationSession, bool> predicate)
        {
            return _sessions.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Removes <see cref="SummationSession"/> 
        /// item from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="SummationSession"/> item to remove</param>
        public void Remove(SummationSession session)
        {
            try
            {
                _sessions.Remove(session);
                SaveChanges();
            }
            catch (ArgumentNullException)
            {

            }
        }

        /// <summary>
        /// Saves changes to database;
        /// </summary>
        private void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
