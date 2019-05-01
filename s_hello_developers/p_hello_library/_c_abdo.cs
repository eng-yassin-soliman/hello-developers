using System;
using System.Collections.Generic;
using System.Text;

namespace p_hello_library
{
    class _c_abdo
    {
        static void Main(string[] args)

        {

       

            int number = 5;

            long fact = GetFactorial(number);

            Console.WriteLine( fact);

            Console.ReadKey();

        }



        private static long GetFactorial(int number)

        {

            if (number == 0)

            {

                return 1;

            }

            return number * GetFactorial(number - 1);

        }




    }
}
