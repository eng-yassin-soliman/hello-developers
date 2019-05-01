using System;
using System.Collections.Generic;
using System.Text;

class _c_abdo
{
    public static int f_factorial_(int p_num_)
    {

            int number = 5;

            long fact = GetFactorial(number);

            Console.WriteLine(fact);

            Console.ReadKey();

            long GetFactorial(int numberr)

            {

                if (numberr == 0)

                {

                    return 1;

                }

                return numberr * GetFactorial(numberr - 1);

            }



 
            return DateTime.Now.Second;



    }
}
