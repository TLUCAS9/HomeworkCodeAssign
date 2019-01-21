using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonData;

namespace ProcessFile
{
    public class InputFileProcessor : IFileProcessor
    {
        public IEnumerable<InputData> ReadFile(string fullFilePath, int fileType)
        {
            List<InputData> inputList = new List<InputData>();

            using (TextReader tr = new StreamReader(new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                switch (fileType)
                {
                    case 1:
                        {
                            inputList = ProcessInput(tr, ReadPipedInput);
                            break;
                        }
                    case 2:
                        {
                            inputList = ProcessInput(tr, ReadSpacesInput);
                            break;
                        }
                    case 3:
                        {
                            inputList = ProcessInput(tr, ReadCSVInput);
                            break;
                        }
                }
            }

            return inputList;
        }

        public void DisplayFile(IEnumerable<InputData> inputList, int sortOrder)
        {

            switch (sortOrder)
            {
                case 1:
                    DisplayRecords(inputList.ToList(), DisplaySortOption1);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public delegate List<InputData> ReadFunction(TextReader tr);
        public delegate void DisplayFunction(IEnumerable<InputData> inputList);

        public static void DisplayRecords(List<InputData> inputData, DisplayFunction displayOutput)
        {
            displayOutput(inputData);
        }

        public static void DisplaySortOption1(IEnumerable<InputData> inputList)
        {
            var dispList = inputList
                .OrderBy(inputRow => inputRow.Gender)
                .ThenBy(inputRow => inputRow.LastName);

            Console.WriteLine("Sort order option 1: Sorted by gender (females before males) then by last name ascending.");
            Console.WriteLine("--------------------------------------");
            foreach (var input in dispList)
            {
                Console.WriteLine(string.Format("Last Name: {0} FirstName: {1} Gender: {2} Favorite Color: {3} Date of Birth: {4}", input.LastName, input.FirstName, input.Gender, input.FavoriteColor, input.DateOfBirth));
            }
        }

        public static void DisplaySortOption2(IEnumerable<InputData> inputList)
        {
            var dispList = inputList
                .OrderBy(inputRow => inputRow.DateOfBirth);

            Console.WriteLine("Sort order option 2: Sorted by birth date, ascending.");
            Console.WriteLine("--------------------------------------");
            foreach (var input in dispList)
            {
                Console.WriteLine(string.Format("Last Name: {0} FirstName: {1} Gender: {2} Favorite Color: {3} Date of Birth: {4}", input.LastName, input.FirstName, input.Gender, input.FavoriteColor, input.DateOfBirth));
            }
        }

        public static void DisplaySortOption3(IEnumerable<InputData> inputList)
        {
            var dispList = inputList
                .OrderBy(inputRow => inputRow.LastName);

            Console.WriteLine("Sort order option 3: Sorted by last name, descending..");
            Console.WriteLine("--------------------------------------");
            foreach (var input in dispList)
            {
                Console.WriteLine(string.Format("Last Name: {0} FirstName: {1} Gender: {2} Favorite Color: {3} Date of Birth: {4}", input.LastName, input.FirstName, input.Gender, input.FavoriteColor, input.DateOfBirth));
            }
        }

        public static List<InputData> ReadPipedInput(TextReader tr)
        {
            List<InputData> inputList = new List<InputData>();

            string line = string.Empty;
            while ((line = tr.ReadLine()) != null)
            {
                List<string> result = line.Split('|').ToList();
                InputData newData = new InputData(result);
                inputList.Add(newData);
            }

            return inputList;
        }

        public static List<InputData> ReadSpacesInput(TextReader tr)
        {
            List<InputData> inputList = new List<InputData>();

            string line = string.Empty;
            while ((line = tr.ReadLine()) != null)
            {
                List<string> result = line.Split(' ').ToList();
                InputData newData = new InputData(result);
                inputList.Add(newData);
            }

            return inputList;
        }

        public static List<InputData> ReadCSVInput(TextReader tr)
        {
            List<InputData> inputList = new List<InputData>();

            string line = string.Empty;
            while ((line = tr.ReadLine()) != null)
            {
                List<string> result = line.Split(',').ToList();
                InputData newData = new InputData(result);
                inputList.Add(newData);
            }

            return inputList;
        }

        public static List<InputData> ProcessInput(TextReader textInput, ReadFunction parseInput)
        {
            List<InputData> inputList = parseInput(textInput);
            return inputList;
        }



    }
}
