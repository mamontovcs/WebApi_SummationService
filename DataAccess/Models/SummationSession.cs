using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Model of summation session
    /// </summary>
    public class SummationSession
    {
        /// <summary>
        /// Session identifier
        /// </summary>
        [Key]
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
