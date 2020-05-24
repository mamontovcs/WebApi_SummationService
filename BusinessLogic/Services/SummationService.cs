using AutoMapper;
using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    /// <summary>
    /// Service for sessions of summaries
    /// </summary>
    internal class SummationService : ISummationService
    {
        /// <summary>
        /// Uses for mapping session object through layers
        /// </summary>
        IMapper _mapper;

        /// <summary>
        /// The Repository mediates between the domain and 
        /// data mapping layers, acting like an in-memory collection of domain objects
        /// </summary>
        private readonly ISummationSessionsRepository _sessionsRepository;

        /// <summary>
        /// Creates instance of <see cref="SummariseService"/>
        /// </summary>
        /// <param name="sessionsRepository"></param>
        public SummationService(ISummationSessionsRepository sessionsRepository)
        {
            _sessionsRepository = sessionsRepository;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<SummationSession, SummationSessionDTO>()).CreateMapper();
        }

        /// <summary>
        /// Gets all sessions
        /// </summary>
        /// <returns>All summaris sessions</returns>
        public virtual List<SummationSessionDTO> GetSessions()
        {
            return _mapper.Map<IEnumerable<SummationSession>, List<SummationSessionDTO>>(_sessionsRepository.Get());
        }

        /// <summary>
        /// Gets one summation session by ID
        /// </summary>
        /// <param name="id">Session identifier</param>
        /// <returns>Session with corresponding identifier</returns>
        public virtual SummationSessionDTO GetSessionById(int id)
        {
            return _mapper.Map<SummationSession, SummationSessionDTO>(_sessionsRepository.GetOne(x => (x.Id == id)));
        }

        /// <summary>
        /// Adds session to database
        /// </summary>
        /// <param name="sessionDTO">Session</param>
        /// <returns></returns>
        public virtual bool AddSession(SummationSessionDTO sessionDTO)
        {
            _sessionsRepository.Create(new SummationSession { DigitX = sessionDTO.DigitX, DigitY = sessionDTO.DigitY, Sum = sessionDTO.Sum });
            return true;
        }

        /// <summary>
        /// Removes session with corresponding from database
        /// </summary>
        /// <param name="id">Session identifier</param>
        /// <returns></returns>
        public virtual bool RemoveSessionByID(int id)
        {
            var toRemove = _sessionsRepository.FindById(id);
            if (toRemove != null)
            {
                _sessionsRepository.Remove(toRemove);
            }

            return true;
        }

        /// <summary>
        /// Calculates sum
        /// </summary>
        /// <param name="x">First digit</param>
        /// <param name="y">Second digit</param>
        /// <returns>Sum of two digits</returns>
        public double CalculateSum(double x, double y)
        {
            return x + y;
        }
    }
}
