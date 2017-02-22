using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegularExpressionAndExceptionHandling;

namespace UnitTestProject1
{
    /// <summary>
    /// Defines tests for the <see cref="ValidPhoneNumber"/> class.
    /// </summary>
    [TestClass]
    public class ValidPhoneNumberTest
    {
        [TestMethod]
        public void Test_PlusSign_USCountryCode_AreaCode_NoSpaces_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("+16306321796"));
        }
        [TestMethod]
        public void Test_PlusSign_USCountryCode_Space_AreaCode_With_Parenthesis_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("+1 (630) 632 1796")); 
        }
        [TestMethod]
        public void Test_USCountryCode_AreaCode_Dashes_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("1-630-632-1976"));
        }
        [TestMethod]
        public void Test_AreaCode_With_Dots_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("630.632.1976"));
        }
        [TestMethod]
        public void Test_AreaCode_With_Parenthesis_With_Slashes_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("(630)/632/1796"));
        }
        [TestMethod]
        public void Test_PhoneNumber_No_Spaces_No_AreaCode_Returns_True()
        {
            Assert.IsTrue(ValidPhoneNumber.PhoneNumber("6321976"));
        }
        [TestMethod]
        public void Test_Astericks_USCountryCode_AreaCode_NoSpaces_ReturnsFalse()
        {
            Assert.IsFalse(ValidPhoneNumber.PhoneNumber("*16304560987"));
        }
        [TestMethod]
        public void Test_NonUSCountryCode_Spaces_AreaCode_ReturnsFalse()
        {
            Assert.IsFalse(ValidPhoneNumber.PhoneNumber("563063214567"));
        }
        [TestMethod]
        public void Test_AreaCode_MoreDigitsThanUSPhoneNumberHas_ReturnsFalse()
        {
            Assert.IsFalse(ValidPhoneNumber.PhoneNumber("630123567890"));
        }
        [TestMethod]
        public void Test_USCountryCode_AreaCode_PoundKeySymbol_ReturnsFalse()
        {
            Assert.IsFalse(ValidPhoneNumber.PhoneNumber("1#630#632#1234"));
        }
    }
}
