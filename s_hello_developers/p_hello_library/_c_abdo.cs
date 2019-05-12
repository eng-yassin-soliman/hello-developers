using System;
using System.Collections.Generic;
using System.Text;

public class _c_abdo
{
    // الدالة اللي انت كاتبها
    public static int f_factorial_(int p_num_)
    {
        int number = 5; // ايه لازمتها؟ عندك باراميتر فوق

        //long fact = 1; // الدالة بترجع انتجر مش لونج

        long fact = long.MaxValue;

        // فين الريكورجن؟
        for (int i = 0; i < 5; i++) // ليه حاطط الخمسة هنا؟
        {
            fact *= number;
            number--;
        }

        return (int)fact;

        Console.WriteLine(fact); // دي كلاس ليبراري عشان نستخدمها من جوة برنامج، مش برنامج

        return DateTime.Now.Second; // محذفتهاش ليه؟
    }

    // الدالة بعد التعديل
    public static int f_factorial_test_(int p_num_)
    {
        int number = p_num_; // 5;

        long fact = 1;
        for (int i = 0; i < p_num_; i++)
        {
            fact *= number;
            number--;
        }

        return (int)fact;

        // Console.WriteLine(fact);
        // return DateTime.Now.Second;
    }
}