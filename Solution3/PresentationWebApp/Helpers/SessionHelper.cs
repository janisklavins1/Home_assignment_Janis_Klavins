﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApp.Helpers
{
    public static class SessionHelper
    {

        public static void SetObjectAsJson(this ISession session, string key, object value)//creating json list
        {
            
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);//if null returns default value, else 
                                                                         //deserialize object T and returns it
        }

    }
}
