// <copyright file="DateTimeExtensions.cs">Copyright (c) 2015 All Rights Reserved </copyright>
// <author>Aloïs Deniel</author>
// <date>6/5/2015 11:22:43 AM</date>

namespace CommonExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// All extensions related to DateTime.
    /// </summary>
    public static class DateTimeExtensions
    {
        #region Timestamps

        /// <summary>
        /// Converts a timestamp to a DateTime
        /// </summary>
        /// <param name="timestamp">The timestamp (milliseconds unix epoch)</param>
        /// <returns>The date time</returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp).ToLocalTime();
        }

        /// <summary>
        /// Converts a DateTime to a timestamp.
        /// </summary>
        /// <param name="datetime">The original date time</param>
        /// <returns>The timestamp (milliseconds unix epoch)</returns>
        public static long ToTimestamp(this DateTime datetime)
        {
            TimeSpan ts = (datetime.ToUniversalTime() - new DateTime(1970, 1, 1,0, 0, 0, DateTimeKind.Utc));
            return (long)ts.TotalMilliseconds;
        }

        #endregion

        #region Comparing to Now
        
        /// <summary>
        /// Elapseds time from now.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns>The elapsed timespan from now.</returns>
        public static TimeSpan Elapsed(this DateTime datetime)
        {
            return DateTime.Now - datetime;
        }

        /// <summary>
        /// Indicates whether the date is older than now.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns>True if the date is older than now.</returns>
        public static bool HasPassed(this DateTime datetime)
        {
            return datetime.Elapsed() > TimeSpan.Zero;
        }

        #endregion
    }
}