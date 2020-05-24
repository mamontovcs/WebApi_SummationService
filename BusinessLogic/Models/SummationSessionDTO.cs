using DataAccess.Models;

namespace BusinessLogic
{
    public class SummationSessionDTO
    {
        /// <summary>
        /// Session identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First digit
        /// </summary>
        public double DigitX { get; set; }

        /// <summary>
        /// Second digit
        /// </summary>
        public double DigitY { get; set; }

        /// <summary>
        /// Sum of first and second digits
        /// </summary>
        public double Sum { get; set; }
    }
}
