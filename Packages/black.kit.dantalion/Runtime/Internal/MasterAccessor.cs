using System;

namespace black.kit.dantalion
{
    /// <summary>The accessor to the master data</summary>
    public static class MasterAccessor
    {
        /// <summary>
        /// Get the coefficients for the underlying life view type.
        /// </summary>
        /// <param name="month">The month</param>
        /// <param name="dateCoefficient">
        /// The coefficient of the date
        /// </param>
        /// <returns>
        /// The coefficients for the underlying life view type.
        /// </returns>
        public static byte GetLifeBaseFactor(int month, int dateCoefficient)
        {
            int index = month - 1;
            byte[] value = MasterData.LifeBaseFactor()[index];
            byte[] threshold = MasterData.LifeBaseThresholds()[index];
            for (int i = 0; i < value.Length; i++)
            {
                if (threshold.Length <= i || dateCoefficient < threshold[i])
                {
                    return value[i];
                }
            }
            return value[value.Length - 1];
        }

        /// <summary>
        /// Gets the monthly coefficient for the specified year and month.
        /// </summary>
        /// <param name="value">
        /// The year and month information to retrieve.
        /// </param>
        /// <returns>The coefficients of the month</returns>
        public static sbyte GetMonthlyCoefficient(DateTime value)
        {
            return GetMonthlyCoefficient(value.Year, value.Month);
        }

        /// <summary>
        /// Gets the monthly coefficient for the specified year and month.
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <returns>The coefficients of the month</returns>
        public static sbyte GetMonthlyCoefficient(int year, int month)
        {
            int index = GetMonthIndex(year, month);
            sbyte[] mc = MasterData.MonthlyCoefficients();
            return index < 0 || mc.Length <= index ? (sbyte)-1 : mc[index];
        }

        /// <summary>月インデックスを算出します。</summary>
        /// <remarks>
        /// 1873 年 2 月を 0 とみなし、そこからの月数をカウントして算出します。
        /// </remarks>
        /// <param name="year">算出したい年。</param>
        /// <param name="month">算出したい月。</param>
        /// <returns>インデックス。</returns>
        private static int GetMonthIndex(int year, int month)
        {
            var since = new DateTime(1873, 2, 1);
            return ((year - since.Year) * 12) + month - since.Month;
        }
    }
}
