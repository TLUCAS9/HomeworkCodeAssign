using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodeAssignProcess;

namespace codeassign.Tests
{
    [TestClass]
    public class ProcessFileTest
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
            InputData testInputGood = new InputData();
            DateTime dateOfBirthTest = new DateTime(1994, 3, 1);
            testInputGood.DateOfBirth = dateOfBirthTest;

            string genderValueTest = "Male";
            testInputGood.Gender = genderValueTest;

            Assert.AreEqual(testInputGood.DateOfBirth, dateOfBirthTest);
            Assert.AreEqual(testInputGood.Gender, genderValueTest);
        }

        [TestMethod]
        public void TestInputPath()
        {

            string filePath = ConfigurationManager.AppSettings["FileDirectory"];
            Assert.IsTrue(!string.IsNullOrEmpty(filePath));
        }

        [TestMethod]
        public void TestPopulateListCSV()
        {
            InputFileProcessor fileInputProcess = new InputFileProcessor();
            List<InputData> inputList = new List<InputData>();
            string filePath = ConfigurationManager.AppSettings["FileDirectory"];
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileName = filePath + "filecomma.csv";
                inputList = fileInputProcess.ReadFile(fileName, 3)
                    .ToList();
            }

            Assert.IsTrue(inputList.Count() != 0);
        }

        [TestMethod]
        public void TestPopulateListPipes()
        {
            InputFileProcessor fileInputProcess = new InputFileProcessor();
            List<InputData> inputList = new List<InputData>();
            string filePath = ConfigurationManager.AppSettings["FileDirectory"];
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileName = filePath + "filepipe.txt";
                inputList = fileInputProcess.ReadFile(fileName, 1)
                    .ToList();
            }

            Assert.IsTrue(inputList.Count() != 0);
        }

        [TestMethod]
        public void TestPopulateListSpaces()
        {
            InputFileProcessor fileInputProcess = new InputFileProcessor();
            List<InputData> inputList = new List<InputData>();
            string filePath = ConfigurationManager.AppSettings["FileDirectory"];
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileName = filePath + "filespace.txt";
                inputList = fileInputProcess.ReadFile(fileName, 2)
                    .ToList();
            }

            Assert.IsTrue(inputList.Count() != 0);
        }
    }
}
