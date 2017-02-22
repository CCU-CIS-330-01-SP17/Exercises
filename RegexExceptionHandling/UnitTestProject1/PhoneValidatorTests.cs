using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexExceptionHandling;
namespace UnitTestProject1
{
    /// <summary>
    /// Defines tests for the <see cref="PhoneValidator"/> class.
    /// </summary>
    [TestClass]
    public class PhoneValidatorTests
    {
        /// <summary>
        /// This method tests to see if the phone number validator correctly returns "true" for each of the valid US phone numbers in a list.
        /// </summary>
        [TestMethod]
        public void ValidateCorrectNumbers()
        {
            string [] validPhoneNumbers = 
                {
                "4221356",
                "422 1356",
                "422.1356",
                "422-1356",
                "422/1356",
                "3034221356",
                "1(303)-422-1356",
                "(303)-422-1356",
                "+1-3034221356",
                "303/422/1356",
                "303.422.1356",
                "1303.422/1356",
                "14225664125"
                };
            foreach (string number in validPhoneNumbers)
            {
                bool validator = new PhoneValidator().validatePhoneNumber(number);
                Console.WriteLine(number + " " + validator);
                Assert.AreEqual(true, validator);
            }
        }

        /// <summary>
        /// This method tests to see if the phone number validator correctly returns "false" for each of the valid US phone numbers in a list.
        /// </summary>
        [TestMethod]
        public void ValidateIncorrectNumbers()
        {
            string[] invalidPhoneNumbers =
                {
                " 4221356",
                "42213562",
                "3034221356 ",
                "((30 3)-422.1356",
                "+2-3034221356",
                "303/422//1356",
                "303.422..1356",
                "1303  422/1356",
                "142256641255"
                };
            foreach (string number in invalidPhoneNumbers)
            {
                bool validator = new PhoneValidator().validatePhoneNumber(number);
                Console.WriteLine(number + " " + validator);
                Assert.AreEqual(false, validator);
            }
        }

        /// <summary>
        /// This method tests to see if the phone number validator correctly throws a ArgumentNullException when a null value is used.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowCorrectException()
        {
            string nullPhoneNumber = null;
            new PhoneValidator().validatePhoneNumber(nullPhoneNumber);
        }
    }
}
