using System;

// التاسك بتاعت السيشن 2
// هاتعمل ملف جديد زي دة فيه كلاس باسمك، بالشكل دة
// وتحط اللوجيك بتاع الفنكشن مكان اللوجيك اللي انا كاتبه
// مطلوب فنكشن بتحسب الفاكتوريال بطريقة ريكروسيف
// recursive factorial function.

public class _c_esmail
{
    public _c_esmail() { }

    public static int f_factorial_(int p_num_)
    {
        if (p_num_ == 0)
            return 1;
        else
            return p_num_*f_factorial_(p_num_-1);
            
    }
}