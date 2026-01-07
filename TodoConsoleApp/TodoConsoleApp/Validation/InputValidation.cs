using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsoleApp.Validation
{
    internal class InputValidation
    {
        static public bool IsYes(string input)
        {
            string trimmed = input.Trim().ToLower();
            if (trimmed == "yes" || trimmed == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public bool IsNo(string input)
        {
            string trimmed = input.Trim().ToLower();
            if (trimmed == "no" || trimmed == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public (bool, int) IsNumber(string input)
        {
            bool success = Int32.TryParse(input, out int num);
            return (success, num);
        }

        static public bool NumberIsInRange(int input, int MaxRange)
        {
            return input >= 0 && input <= MaxRange;
        }
    }
}
