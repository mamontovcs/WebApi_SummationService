using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    /// <summary>
    /// The Repository mediates between the domain and 
    /// data mapping layers, acting like an in-memory collection of domain objects
    /// </summary>
    public interface ISummationSessionsRepository
    {
        /// <summary>
        /// Adds <see cref="SummationSession"/> item to the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="SummationSession"/>Session to add</param>
        void Create(SummationSession session);

        /// <summary>
        /// Finds <see cref="ISummationSession"/> item in the corresponding
        /// <see cref="DatabaseContext"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="SummationSession"/>Found object</returns>
        SummationSession FindById(int id);

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>All <see cref="SummationSession"/> Objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        IEnumerable<SummationSession> Get();

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="SummationSession"/> objects 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        IEnumerable<SummationSession> Get(Func<SummationSession, bool> predicate);

        /// <summary>
        /// Gets first corresponding object by 
        /// predicate from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <returns>Founded <see cref="SummationSession"/> object 
        /// from corresponding <see cref="DatabaseContext"/></returns>
        SummationSession GetOne(Func<SummationSession, bool> predicate);

        /// <summary>
        /// Removes <see cref="SummationSession"/> 
        /// item from the corresponding <see cref="DatabaseContext"/>
        /// </summary>
        /// <param name="session"><see cref="SummationSession"/> item to remove</param>
        void Remove(SummationSession session);
    }
}
