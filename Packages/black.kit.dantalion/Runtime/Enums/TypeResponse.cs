namespace black.kit.dantalion
{
    /// <summary>The types of roles</summary>
    public enum TypeResponse : int
    {
        /// <summary>
        /// This type of person would like to always act with customers
        /// </summary>
        Action,

        /// <summary>
        /// This type of person would like to
        /// always act with only known peoples
        /// </summary>
        Mind,

        /// <summary>Maximum value of the enumeration.</summary>
        /// <remarks>This value is not valid as an index.</remarks>
        MAX_VALUE,
    }
}
