namespace black.kit.dantalion
{
    /// <summary>The index of birthday information.</summary>
    public enum BirthdayIndex : int
    {
        /// <summary>The date.</summary>
        Date,

        /// <summary>Whether the month is January or February.</summary>
        EarlyMonth,

        /// <summary>The month.</summary>
        Month,

        /// <summary>
        /// The value shifted to treat January and February
        /// as the 13th and 14th months.
        /// </summary>
        ShiftedMonth,

        /// <summary>The year.</summary>
        Year,

        /// <summary>The upper 2 digits of the year.</summary>
        HiYear,

        /// <summary>The lower 2 digits of the year.</summary>
        LoYear,

        /// <summary>Maximum value of the enumeration.</summary>
        /// <remarks>This value is not valid as an index.</remarks>
        MAX_VALUE,
    }
}
