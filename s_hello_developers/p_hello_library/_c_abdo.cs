using System;
using System.Collections.Generic;
using System.Text;

class _c_abdo
{
    public static int f_factorial_(int p_num_)
    {

            int number = 5;
        long fact =1;
        for (int i = 0; i < 5; i++)
        {
            fact *= number;
            number--;
        }

            Console.WriteLine(fact);

            return DateTime.Now.Second;

    }
}
