namespace black.kit.dantalion
{
    /// <summary>The types that the risk management method</summary>
    public enum TypeManagement : int
    {
        /// <summary>
        /// This type of person has a good intuition
        /// for risk but weak for chance perception.
        /// </summary>
        Care,

        /// <summary>
        /// This type of person has a good intuition
        /// for great opportunities, but weak risk perception
        /// </summary>
        Hope,

        /// <summary>Maximum value of the enumeration.</summary>
        /// <remarks>This value is not valid as an index.</remarks>
        MAX_VALUE,
    }
}
