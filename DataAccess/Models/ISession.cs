namespace DataAccess.Models
{
    /// <summary>
    /// Interface that represents the
    /// summation session
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// First digit
        /// </summary>
        double DigitX { get; set; }

        /// <summary>
        /// Second digit
        /// </summary>
        double DigitY { get; set; }

        /// <summary>
        /// Sum of first and second digits
        /// </summary>
        double Sum { get; set; }
    }
}
