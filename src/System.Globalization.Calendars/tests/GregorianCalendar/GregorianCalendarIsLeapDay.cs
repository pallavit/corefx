// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Xunit;

using static System.Globalization.Tests.GregorianCalendarTestUtilities;

namespace System.Globalization.Tests
{
    public class GregorianCalendarIsLeapDay
    {
        private static readonly RandomDataGenerator s_randomDataGenerator = new RandomDataGenerator();

        public static IEnumerable<object[]> IsLeapDay_TestData()
        {
            int randomYear = RandomYear();
            int randomMonth = RandomMonth();

            // 29th February on a leap year
            yield return new object[] { RandomLeapYear(), 2, 29 };

            // 28th February on a common year
            yield return new object[] { RandomCommonYear(), 2, 28 };

            // Any day, any month, any day
            yield return new object[] { randomYear, randomMonth, RandomDay(randomYear, randomMonth) };

            // Any day, any month in the maximum supported year
            yield return new object[] { 9999, randomMonth, RandomDay(9999, randomMonth) };

            // Any day, any month in the minimum supported year
            yield return new object[] { 1, randomMonth, RandomDay(1, randomMonth) };
        }

        [Theory]
        [MemberData(nameof(IsLeapDay_TestData))]
        public void IsLeapDay(int year, int month, int day)
        {
            bool expected = IsLeapYear(year) && month == 2 && day == 29;
            Assert.Equal(expected, new GregorianCalendar().IsLeapDay(year, month, day, 1));
        }
    }
}
