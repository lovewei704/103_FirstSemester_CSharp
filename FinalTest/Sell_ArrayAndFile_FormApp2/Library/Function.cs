using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Function
    {
        public int CheckInt(int a, int b)
        {
            if (a < b)
                return -1;
            else if (a > b)
                return 1;
            else
                return 0;
        }//end int

        public double CheckDouble(double a, double b)
        {
            if (a < b)
                return -1;
            else if (a > b)
                return 1;
            else
                return 0;
        }//end double

        public decimal CheckDecimal(decimal a, decimal b)
        {
            if (a < b)
                return -1;
            else if (a > b)
                return 1;
            else
                return 0;
        }//end decimal
    }
}
