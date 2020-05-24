using System.Collections.Generic;

namespace BusinessLogic
{
    /// <summary>
    /// Service for sessions of summation
    /// </summary>
    public interface ISummationService
    {
        /// <summary>
        /// Gets all sessions
        /// </summary>
        /// <returns>All summation sessions</returns>
        List<SummationSessionDTO> GetSessions();

        /// <summary>
        /// Gets one summation session by ID
        /// </summary>
        /// <param name="id">Session identifier</param>
        /// <returns>Session with corresponding identifier</returns>
        SummationSessionDTO GetSessionById(int id);

        /// <summary>
        /// Adds session to database
        /// </summary>
        /// <param name="sessionDTO">Session</param>
        /// <returns></returns>
        bool AddSession(SummationSessionDTO sessionDTO);

        /// <summary>
        /// Removes session with corresponding from database
        /// </summary>
        /// <param name="id">Session identifier</param>
        /// <returns></returns>
        bool RemoveSessionByID(int id);

        /// <summary>
        /// Calculates sum
        /// </summary>
        /// <param name="x">First digit</param>
        /// <param name="y">Second digit</param>
        /// <returns>Sum of two digits</returns>
        double CalculateSum(double x, double y);
    }
}
