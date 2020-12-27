using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppManagerContent.Helpers
{
    public static class Extensions
    {
        public static string ToJSON(this IFormCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                if (!key.Equals("__RequestVerificationToken"))
                {
                    list.Add(key, collection[key]);
                }
            }
            return JsonConvert.SerializeObject(list);
        }

        public static byte[] Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            //return System.Convert.ToBase64String(plainTextBytes);
            return plainTextBytes;
        }
    }
}