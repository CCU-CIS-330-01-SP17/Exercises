using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegExandExceptionHandling;

namespace RegExandExceptionHandlingTests
{
    [TestClass]
    public class PhoneVerifierTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Whitespace_Parameter_Throws_Argument_Exception()
        {
            PhoneVerifier.IsValidNumber(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Null_Parameter_Throws_Argument_Exception()
        {
            PhoneVerifier.IsValidNumber(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Empty_Parameter_Throws_Argument_Exception()
        {
            PhoneVerifier.IsValidNumber("");
        }

        [TestMethod]
        public void No_Hyphens_Phone_Is_Valid()
        {
            Assert.IsTrue(PhoneVerifier.IsValidNumber("+18008669000"));
        }

        [TestMethod]
        public void Parenthasis_Phone_Is_Valid()
        {
            Assert.IsTrue(PhoneVerifier.IsValidNumber("(800) 866-9000"));
        }

        [TestMethod]
        public void No_Hyphens_No_One_Phone_Is_Valid()
        {
            Assert.IsTrue(PhoneVerifier.IsValidNumber("8008669000"));
        }

        [TestMethod]
        public void Dots_Phone_Is_Valid()
        {
            Assert.IsTrue(PhoneVerifier.IsValidNumber("1.800.866.9000"));
        }

        [TestMethod]
        public void Mixed_Spacing_Phone_Is_Valid()
        {
            Assert.IsTrue(PhoneVerifier.IsValidNumber("1.800/866-9000"));
        }

        [TestMethod]
        public void No_One_Preceeding_Space_Is_Not_Valid()
        {
            Assert.IsFalse(PhoneVerifier.IsValidNumber(" (800)8669000"));
        }

        [TestMethod]
        public void Ending_Space_Is_Not_Valid()
        {
            Assert.IsFalse(PhoneVerifier.IsValidNumber("1.800.866.9000 "));
        }

        [TestMethod]
        public void Plus_With_No_One_Phone_Is_Not_Valid()
        {
            Assert.IsFalse(PhoneVerifier.IsValidNumber("+(800) 866-9000"));
        }

        [TestMethod]
        public void Unmatched_Parenthesis_Phone_Is_Not_Valid()
        {
            Assert.IsFalse(PhoneVerifier.IsValidNumber("(800 866-9000"));
        }

        [TestMethod]
        public void Other_Deliminators_Are_Not_Valid()
        {
            Assert.IsFalse(PhoneVerifier.IsValidNumber(@"1\900\866\700"));
        }
    }
} 
