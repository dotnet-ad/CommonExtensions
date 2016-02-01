// <author>Aloïs Deniel</author>
// <date>6/4/2015 11:31:06 AM</date>

namespace CommonExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// All extensions on string.
    /// </summary>
    public static class StringExtensions
    {
        #region Emails

        /// <summary>
        /// The regular expression pattern for validating an email.
        /// </summary>
        public const string EmailPattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)";

        /// <summary>
        /// Indicates whether a string is a valid email.
        /// </summary>
        /// <param name="text">The email string that must be validated.</param>
        /// <returns>Returns true if the given string is an email, else false.</returns>
        public static bool IsValidEmail(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return false;

            text = text.Trim();

            try
            {
                return Regex.IsMatch(text, @"\A" + EmailPattern + @"\Z", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Extracts all email from a given string.
        /// </summary>
        /// <param name="text">The given string.</param>
        /// <returns>A collection of all email found in the given string.</returns>
        public static IEnumerable<String> ExtractEmails(this string text)
        {
            Regex rx = new Regex(EmailPattern, RegexOptions.IgnoreCase);
            return rx.Matches(text).Cast<Match>().Select((m) => m.Value.ToString());
        }

        #endregion
    }
}