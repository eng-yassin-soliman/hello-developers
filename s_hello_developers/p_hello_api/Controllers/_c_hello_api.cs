﻿using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace p_hello_api
{
    [Route("hello/api")] 
    [ApiController] 
    public class _c_hello_api : Controller
    {
        [HttpPost]
        [Route("text")]
        public string f_text_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            return l_txt_;
        }

        [HttpPost]
        [Route("byte")]
        public string f_byte_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_txt_);
            StringBuilder l_str_ = new StringBuilder(string.Empty);
            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString("000"));
                l_str_.Append(Encoding.UTF8.GetString(new byte[] { 10 }));
                // New line           
            }
            return l_str_.ToString();
        }

        class ffff
        {
            [JsonConverter(typeof(ByteArrayConvertor))]
            public byte[] l_byt_ = { 0, 1, 2, 3 };
        }

        public class ByteArrayConvertor : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                throw new NotImplementedException();
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return new byte[] { 0, 1, 2 };
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue("[0, 1, 2]");
            }
        }

        public class _c_complex
        {
            public string s_str_ = "hello";

            [JsonConverter(typeof(ByteArrayConvertor))]
            public int[] s_byt_ = { 0, 1, 2, 3, 4, 5, 6, 7 };
        }

        [HttpPost]
        [Route("base64")]
        public _c_complex f_base64_()
        {
            return new _c_complex();
        }
    }
}