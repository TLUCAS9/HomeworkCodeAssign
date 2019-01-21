using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.Globalization;

namespace CommonData
{
    public class InputData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColor { get; set; }

        private DateTime ValueDOB { get; set; }
        private string ValueGender { get; set; }

        private static readonly string[] genderArray = { "M", "F", "m", "f", "Male", "Female" };

        public DateTime DateOfBirth
        {
            get
            {
                return ValueDOB;
            }
            set
            {
                ValueDOB = value > new DateTime(1900, 1, 1) ? value : new DateTime(1900, 1, 1);
            }
        }

        public string Gender

        {
            get
            {
                return ValueGender;
            }
            set
            {
                ValueGender = genderArray.Contains(HttpUtility.HtmlEncode(value)) ? value : "";
            }
        }

        public InputData(List<string> newInput)
        {
            LastName = newInput[0].Trim();
            FirstName = newInput[1].Trim();
            Gender = newInput[2].Trim();
            FavoriteColor = newInput[3].Trim();
            DateTime newDOB = DateTime.MinValue;
            if (DateTime.TryParse(newInput[4], out newDOB))
            {
                DateOfBirth = newDOB;
            }
        }

        public InputData()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            Gender = string.Empty;
            FavoriteColor = string.Empty;
            DateOfBirth = DateTime.MinValue;
        }

        public InputData(InputData copy)
        {
            LastName = copy.LastName;
            FirstName = copy.FirstName;
            Gender = copy.Gender;
            FavoriteColor = copy.FavoriteColor;
            DateOfBirth = copy.DateOfBirth;
        }
    }

    public enum InputType
    {
            [Description("Piped Format")]
            Pipe = 1,
            [Description("Spaces Format")]
            Space = 2,
            [Description("CSV Format")]
            CSV = 3
     }
}
