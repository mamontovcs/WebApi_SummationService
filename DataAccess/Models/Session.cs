namespace DataAccess.Models
{
    /// <summary>
    /// Model of summation session
    /// Implements <see cref="ISession>
    /// </summary>
    public class Session : ISession
    {
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
