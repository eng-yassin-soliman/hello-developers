using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Translator;

namespace p_hello_xamarin
{
    public static class _c_translation
    {
        // Yandex translation API key
        static string s_key_ = "trnsl.1.1.20190831T014229Z.09dc6c21bfa3fbee.6124374ef9690bafc62c55f6d1f0b5afe6fb4759";

        public static string f_translate_(string p_inp_)
        {
            IYandexTranslator l_tra_ = Yandex.Translator.Yandex.Translator(
                p_api_ => p_api_.ApiKey(s_key_).Format(ApiDataFormat.Json));

            return l_tra_.Translate(p_req_ => p_req_.From("en").To("ar").Text(p_inp_)).Text;
        }
    }
}