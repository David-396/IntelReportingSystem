using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelReportingSystem.Validations
{
    public static class ValidateInput
    {
        public static bool Validate(string opt1, string opt2, string input)
        {
            if(opt1 == input || opt2 == input)
            {
                return true;
            }
            return false;
        }
        public static bool Validate(string opt1, string opt2, string opt3, string input)
        {
            if (opt1 == input || opt2 == input || opt3 == input)
            {
                return true;
            }
            return false;
        }
        public static bool Validate(string opt1, string opt2, string opt3, string opt4, string opt5, string opt6, string input)
        {
            if (opt1 == input || opt2 == input || opt3 == input || opt4 == input || opt5 == input || opt6 == input)
            {
                return true;
            }
            return false;
        }
    }
}
