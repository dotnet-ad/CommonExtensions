using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonExtensions.Tests
{
    [TestClass]
    public class StringTests
    {
        #region Emails

        public const string textContainingEmails = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. phasellus.mollis@test.com sem nec est condimentum, viverra tempor risus mattis. Sed lacinia pulvinar enim.consequat@fermentum.org Proin rhoncus magna sed est maximus facilisis. Nulla sodales tellus sed augue molestie iaculis. Nulla molestie, arcu a euismod pharetra, neque orci mollis urna, in consectetur est orci quis tellus. Morbi venenatis euismod erat, eget mollis orci rhoncus ac. Morbi vel rhoncus leo, vitae pellentesque enim. Sed tincidunt consectetur interdum. In at erat facilisis, semper purus eu, aliquet odio. Proin iaculis, massa quis vehicula congue, sapien massa lacinia metus, a laoreet eros eros at nibh. Nunc eleifend finibus nisl. Quisque blandit ullamcorper nisi, eget malesuada purus tempor ut.";
        public static readonly string[] emailsContainedInText = new string[] { "phasellus.mollis@test.com", "enim.consequat@fermentum.org" };


        public static readonly string[] validEmails = new string[]
        {
            "first.last@test.org",
            "1234567890123456789012345678901234567890123456789012345678901234@test.org"
        };

        public static readonly string[] invalidEmails = new string[]
        {
            "first..last@iana.org"
        };

        [TestMethod]
        public void IsValidEmail()
        {
            foreach (var email in validEmails)
            {
                Assert.IsTrue(email.IsValidEmail());
            }

            foreach (var email in invalidEmails)
            {
                Assert.IsFalse(email.IsValidEmail());
            }
        }

        [TestMethod]
        public void ExtractEmails()
        {
            var extractedEmails = textContainingEmails.ExtractEmails();
            
            foreach (var email in emailsContainedInText)
	        {
                Assert.IsTrue(extractedEmails.Contains(email));
	        }
        }

        #endregion
    }
}
