using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonExtensions.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        #region Timestamps

        private const long timestamp = 1433670962000;
        private static readonly DateTime datetime = new DateTime(2015, 6, 7, 11, 56, 2);

        [TestMethod]
        public void ToDateTime()
        {
            var convertedDatetime = timestamp.ToDateTime();

            Assert.AreEqual(datetime,convertedDatetime);
        }

        [TestMethod]
        public void ToTimestamp()
        {
            var convertedTimestamp = datetime.ToTimestamp();

            Assert.AreEqual(timestamp, convertedTimestamp);
        }

        #endregion

        #region Comparing to Now

        [TestMethod]
        public void HasPassed()
        {
            var passed = datetime.HasPassed();

            Assert.AreEqual(true, passed);
        }

        #endregion
    }
}
