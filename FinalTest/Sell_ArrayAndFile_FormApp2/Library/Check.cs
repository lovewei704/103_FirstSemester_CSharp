using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Check
    {
        Function ToFunction = new Function();
        decimal input_decimal;
        double input_double;
        int input_int;

        // flagvalue = -1,0,1  ---->  <,=,>  
        public bool checkFile(string fileName)
        {
            bool check = false;
            if (fileName == string.Empty)
            {
                Console.WriteLine("Invalid File Name");
            }
            else
            {
                check = true;
            }
            return check;
        }//end check file

        public bool checkint(string input, int min, int max, int flagvalue)
        {
            bool check = false;

            try
            {
                input_int = int.Parse(input);
                if (ToFunction.CheckInt(input_int, min) == flagvalue)
                {
                    if (ToFunction.CheckInt(input_int, max) == -1)
                        check = true;
                }
            }
            catch { }

            return check;
        } // end check int

        public bool checkdecimal(string input, decimal min, decimal max, decimal flagvalue)
        {
            bool check = false;

            try
            {
                input_decimal = decimal.Parse(input);
                if (ToFunction.CheckDecimal(input_decimal, min) == flagvalue)
                {
                    if (ToFunction.CheckDecimal(input_decimal, max) == -1)
                        check = true;
                }
            }
            catch { }
            return check;
        } // end check decimal

        public bool checkdouble(string input, double min, double max, double flagvalue)
        {
            bool check = false;

            try
            {
                input_double = double.Parse(input);
                if (ToFunction.CheckDouble(input_double, min) == flagvalue)
                {
                    if (ToFunction.CheckDouble(input_double, max) == -1)
                        check = true;
                }
            }
            catch { }
            return check;
        } // end check double
        public bool checkdou(string input, double min, double max, double flagvalue)
        {
            bool check = false;
            try
            {
                input_double = double.Parse(input);
                if (input_double <= max && input_double >= min)
                    check = true;

            }
            catch { }
            return check;
        }
        public bool checkstring(string input)
        {
            bool check = false;
            if (input == string.Empty)
            { check = false; }
            else check = true;

            return check;
        }
    }
}
