using System;

namespace p_math_helper
{
    public class _c_math_helper
    {
        public static double add(double num1, double num2)
        {
            double result = num1 + num2;
            return result;
        }

        public static double subtract(double num1, double num2)
        {
            double result = num1 - num2;
            return result;
        }

        public static double multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return result;
        }

        public static double divide(double num1, double num2)
        {
            double result = num1 / num2;
            return result;
        }

        public static double factorial(double num1)
        {
            if (num1 == 1)
                return 1;
            return num1 * factorial(num1 - 1);
        }

        public static double squareroot(double num)
        {
            return 0;
        }
    }
}