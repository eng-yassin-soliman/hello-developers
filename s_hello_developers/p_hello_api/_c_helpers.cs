using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace p_hello_api
{
    public class _c_js_ar_byte : JsonConverter<byte[]>
    {
        public override byte[] ReadJson(JsonReader p_red_, Type p_typ_, byte[] p_val_, bool p_has_, JsonSerializer p_ser_)
        {
            JToken l_tkn_ = JToken.Load(p_red_);
            return (byte[])l_tkn_.ToObject(p_typ_);
        }

        public override void WriteJson(JsonWriter p_wrt_, byte[] p_val_, JsonSerializer p_ser_)
        {
            int[] l_int_ = (from i_byt_ in p_val_ select (int)i_byt_).ToArray();
            JArray l_jar_ = new JArray(l_int_);
            l_jar_.WriteTo(p_wrt_);
        }
    }
}