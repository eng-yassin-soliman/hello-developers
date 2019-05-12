using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class _c_shorouk1
{
    public static long f_factorial_(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        else
        {
            return n * f_factorial_(n - 1);
        }
    }
}