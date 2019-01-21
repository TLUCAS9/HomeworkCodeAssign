using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonData;

namespace codeassign.Tests
{
    [TestClass]
    public class InputDataTest
    {
        [TestMethod]
        public void TestBadDataInput()
        {
            InputData testInputBad = new InputData();
            DateTime dateOfBirthTest = new DateTime(1800, 5, 3);
            testInputBad.DateOfBirth = dateOfBirthTest;

            string genderValueTest = "GenderInput";
            testInputBad.Gender = genderValueTest;

            Assert.AreEqual(testInputBad.DateOfBirth, new DateTime(1900, 1, 1));
            Assert.AreEqual(testInputBad.Gender, "");

            genderValueTest = "<script>alert('test')</script>";
            testInputBad.Gender = genderValueTest;
        }

        [TestMethod]
        public void TestGoodDataInput()
        {
            InputData testInputGood = new InputData();
            DateTime dateOfBirthTest = new DateTime(1994, 3, 1);
            testInputGood.DateOfBirth = dateOfBirthTest;

            string genderValueTest = "Male";
            testInputGood.Gender = genderValueTest;

            Assert.AreEqual(testInputGood.DateOfBirth, dateOfBirthTest);
            Assert.AreEqual(testInputGood.Gender, genderValueTest);
        }

        [TestMethod]
        public void TestFileFormatType()
        {
            /*InputData testInputGood = new InputData();
            DateTime dateOfBirthTest = new DateTime(1994, 3, 1);
            testInputGood.DateOfBirth = dateOfBirthTest;

            string genderValueTest = "Male";
            testInputGood.Gender = genderValueTest;

            Assert.AreEqual(testInputGood.DateOfBirth, dateOfBirthTest);
            Assert.AreEqual(testInputGood.Gender, genderValueTest);*/
        }
    }
}
