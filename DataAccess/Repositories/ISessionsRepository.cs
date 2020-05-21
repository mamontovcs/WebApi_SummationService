using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    /// <summary>
    /// The Repository mediates between the domain and 
    /// data mapping layers, acting like an in-memory collection of domain objects
    /// </summary>
    public interface ISessionsRepository
    {
        /// <summary>
        /// Adds <see cref="ISession"/> item to the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/>Session to add</param>
        void Create(ISession session);

        /// <summary>
        /// Finds <see cref="ISession"/> item in the corresponding
        /// <see cref="DatabaseContext"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="ISession"/>Found object</returns>
        ISession FindById(int id);

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>All <see cref="ISession"/> Objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        IEnumerable<ISession> Get();

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="ISession"/> objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        IEnumerable<ISession> Get(Func<ISession, bool> predicate);

        /// <summary>
        /// Gets first corresponding object by 
        /// predicate from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>Founded <see cref="ISession"/> object 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        ISession GetOne(Func<ISession, bool> predicate);

        /// <summary>
        /// Removes <see cref="ISession"/> 
        /// item from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/> item to remove</param>
        void Remove(ISession session);

        /// <summary>
        /// Updates <see cref="ISession"/> item in the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="ISession"/> item to update</param>
        void Update(ISession session);
    }
}
