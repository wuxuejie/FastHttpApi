﻿using BeetleX.FastHttpApi;
using System;

namespace HttpApiServer.Cookies
{
    class Program
    {
        private static BeetleX.FastHttpApi.HttpApiServer mApiServer;

        static void Main(string[] args)
        {
            mApiServer = new BeetleX.FastHttpApi.HttpApiServer();
            mApiServer.ServerConfig.BodySerializer = new JsonBodySerializer();
            mApiServer.Register(typeof(Program).Assembly);
            mApiServer.Debug();
            mApiServer.Open();
            Console.Write(mApiServer.BaseServer);
            Console.Read();
        }
    }

    [Controller]
    public class Test
    {
        public bool setCookie(string name, string value, HttpResponse response)
        {
            response.SetCookie(name, value);
            return true;
        }

        public string getCookie(string name, HttpRequest request, HttpResponse response)
        {
            string value = request.Cookies[name];
            return value;
        }
    }
}
