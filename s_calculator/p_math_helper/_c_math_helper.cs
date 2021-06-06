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

        public static double sub(double num1, double num2)
        {
            double result = num1 - num2;
            return result;
        }

        public static double multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return result;
        }

        public static double div(double num1, double num2)
        {
            double result = num1 / num2;
            return result;
        }

        public static double fact(double num1)
        {
            if (num1 == 1)
                return 1;
            return num1 * fact(num1 - 1);
        }
    }
}