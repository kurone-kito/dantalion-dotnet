using System;

namespace black.kit.dantalion
{
    /// <summary>The core logics of the Dantalion.</summary>
    public static class Dantalion
    {
        /// <summary>Get the details of the genius type.</summary>
        /// <param name="genius">The genius type.</param>
        /// <returns>The details of the genius type.</returns>
        /// <seealso cref="DetailIndex"/>
        public static byte[] GetGeniusDetail(this TypeGenius genius)
        {
            int index = (int)genius;
            if (index < 0 || index >= (int)TypeGenius.MAX_VALUE)
            {
                return null;
            }
            return MasterData.DetailsMap()[index];
        }

        /// <summary>Get the personality information.</summary>
        /// <param name="birth">Date of birth.</param>
        /// <returns>Personality information.</returns>
        /// <seealso cref="PersonalityIndex"/>
        public static byte[] GetPersonality(this DateTime birth)
        {
            sbyte monthlyCoefficient =
                MasterAccessor.GetMonthlyCoefficient(birth);
            if (monthlyCoefficient < 0)
            {
                return null;
            }
            int[] birthDetails = birth.GetDateDetails();
            int[] factors = GetFactors(birthDetails, monthlyCoefficient);
            int cycleIndex = (int)PersonalityIndex.Cycle;
            int lbIndex = (int)PersonalityIndex.LifeBase;
            int innerIndex = (int)PersonalityIndex.Inner;
            int outerIndex = (int)PersonalityIndex.Outer;
            int paIndex = (int)PersonalityIndex.PotentialA;
            int pbIndex = (int)PersonalityIndex.PotentialB;
            int wsIndex = (int)PersonalityIndex.WorkStyle;
            byte LifeBase = MasterAccessor.GetLifeBaseFactor(
                birthDetails[(int)BirthdayIndex.Month], factors[lbIndex]);
            int cycle = factors[cycleIndex];
            int y = cycle % 10;
            byte[] ps = new byte[factors.Length];
            byte[][] geniusTable = MasterData.Genius();
            byte[][] potentialTable = MasterData.Potential();
            ps[cycleIndex] = (byte)(Math.Abs(cycle) & byte.MaxValue);
            ps[innerIndex] = geniusTable[y][factors[innerIndex] - 1];
            ps[lbIndex] = MasterData.LifeBase()[y][LifeBase - 1];
            ps[outerIndex] = geniusTable[y][factors[outerIndex] - 1];
            ps[paIndex] = potentialTable[y][factors[paIndex] - 1];
            ps[pbIndex] = potentialTable[y][factors[pbIndex] - 1];
            ps[wsIndex] = geniusTable[y][factors[wsIndex] - 1];
            return ps;
        }

        /// <summary>Get the date details.</summary>
        /// <param name="birth">Date of birth.</param>
        /// <returns>Date details.</returns>
        /// <seealso cref="BirthdayIndex"/>
        private static int[] GetDateDetails(this DateTime birth)
        {
            int[] details = new int[(int)BirthdayIndex.MAX_VALUE];
            details[(int)BirthdayIndex.Date] = birth.Day;
            details[(int)BirthdayIndex.EarlyMonth] = birth.Month <= 2 ? 1 : 0;
            details[(int)BirthdayIndex.Month] = birth.Month;
            details[(int)BirthdayIndex.ShiftedMonth] =
                birth.Month + (12 * details[(int)BirthdayIndex.EarlyMonth]);
            details[(int)BirthdayIndex.Year] = birth.Year;
            details[(int)BirthdayIndex.HiYear] = birth.Year / 100;
            details[(int)BirthdayIndex.LoYear] = birth.Year % 100;
            return details;
        }

        /// <summary>
        /// Get the factors for personality determination.
        /// </summary>
        /// <param name="dateDetails">Date details.</param>
        /// <param name="monthlyCoefficient">Monthly coefficient.</param>
        /// <returns>Factors for personality determination.</returns>
        /// <seealso cref="PersonalityIndex"/>
        private static int[] GetFactors(int[] dateDetails, sbyte monthlyCoefficient)
        {
            int date = dateDetails[(int)BirthdayIndex.Date];
            int earlyMonth = dateDetails[(int)BirthdayIndex.EarlyMonth];
            int month = dateDetails[(int)BirthdayIndex.Month];
            int shiftedMonth = dateDetails[(int)BirthdayIndex.ShiftedMonth];
            int year = dateDetails[(int)BirthdayIndex.Year];
            int hiYear = dateDetails[(int)BirthdayIndex.HiYear];
            int loYear = dateDetails[(int)BirthdayIndex.LoYear];
            bool lessThan = date < monthlyCoefficient;
            int outer = ShiftModulo(month - (lessThan ? 1 : 0), 12) + 1;
            int workStyle = year + 9 -
                (lessThan ? earlyMonth : month == 1 ? 1 : 0);
            int cycle =
                (int)(hiYear * 4.25f) + (int)((shiftedMonth + 1) * 0.6f) +
                // NOTE: In the case of a negative number, casting int
                // results in a “rounding up” behavior. Therefore,
                // perform an explicit Floor conversion before casting.
                (int)Math.Floor((loYear - earlyMonth) * 5.25) + date + 7;
            int potentialA = ShiftModulo(workStyle - 2, 10);
            int potentialB = ShiftModulo((year * 2) + outer + 2, 10);
            int[] factors = new int[(int)PersonalityIndex.MAX_VALUE];
            factors[(int)PersonalityIndex.Cycle] = ShiftModulo(cycle, 10);
            factors[(int)PersonalityIndex.Inner] =
                ShiftModulo((shiftedMonth * 6) + (hiYear * 4) + cycle - 6, 12);
            factors[(int)PersonalityIndex.LifeBase] = date - monthlyCoefficient;
            factors[(int)PersonalityIndex.Outer] = ShiftModulo(outer, 12);
            factors[(int)PersonalityIndex.PotentialA] = potentialA;
            factors[(int)PersonalityIndex.PotentialB] = potentialB;
            factors[(int)PersonalityIndex.WorkStyle] = ShiftModulo(workStyle, 12);
            return factors;
        }

        /// <summary>
        /// Performs a 1-based cyclic wrap of the given integer
        /// <paramref name="a"/> into the range [1, <paramref name="n"/>].
        /// This handles values of <paramref name="a"/> that are outside
        /// the range or negative, always returning a result between 1 and
        /// <paramref name="n"/> inclusive.
        /// </summary>
        /// <param name="a">
        /// The input value (1-based) to be wrapped. May be any integer.
        /// </param>
        /// <param name="n">
        /// The cycle length (modulus divisor). Must be non-zero; defines the upper bound of the range.
        /// </param>
        /// <returns>
        /// An integer in the range [1, <paramref name="n"/>], obtained by wrapping <paramref name="a"/> around the cycle.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown when <paramref name="n"/> is zero.
        /// </exception>
        private static int ShiftModulo(int a, int n)
        {
            return ((((a - 1) % n) + n) % n) + 1;
        }
    }
}
