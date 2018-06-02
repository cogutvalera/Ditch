﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.BitShares.Tests
{
    public class BaseTest
    {
        private bool IgnoreRequestWithBadData = true;
        protected static UserInfo User;
        protected static OperationManager Api;
        protected string SbdSymbol = "BTS";

        static BaseTest()
        {
            User = new UserInfo
            {
                Login = ConfigurationManager.AppSettings["Login"],
                ActiveWif = ConfigurationManager.AppSettings["ActiveWif"],
                OwnerWif = ConfigurationManager.AppSettings["OwnerWif"]
            };
            // Assert.IsFalse(string.IsNullOrEmpty(User.ActiveWif));
            var jss = GetJsonSerializerSettings();
            // var manager = new WebSocketManager(jss, 1024 * 1024);
            var manager = new HttpManager(jss);
            Api = new OperationManager(manager, jss);
            var urls = new List<string> { ConfigurationManager.AppSettings["Url"] };
            var connectedTo = Api.TryConnectTo(urls, CancellationToken.None);
            Assert.IsFalse(string.IsNullOrEmpty(connectedTo), $"Enable connect to {string.Join(", ", urls)}");
        }

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var rez = new JsonSerializerSettings
            {
                // DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = CultureInfo.InvariantCulture
            };
            return rez;
        }

        protected void TestPropetries(Type type, JObject jObject)
        {
            var propNames = GetPropertyNames(type);

            var chSet = jObject.Children();

            var msg = new List<string>();
            foreach (JProperty jtoken in chSet)
            {
                if (!propNames.Contains(jtoken.Name))
                {
                    msg.Add($"Missing {jtoken}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        protected void TestPropetries(Type type, JArray jArray)
        {
            if (jArray == null)
                throw new NullReferenceException("jArray");

            if (type.IsArray)
            {
                if (jArray.Count > 0)
                    TestPropetries(type.GetElementType(), (JObject)jArray[0]);
                else if (!IgnoreRequestWithBadData)
                    throw new NullReferenceException("Impossible to do test for this input data!");
            }
            else
                throw new InvalidCastException();
        }

        protected void TestPropetries(Type type, JObject[] jObject)
        {
            if (jObject == null)
                throw new NullReferenceException("jObject");

            if (type.IsArray)
            {
                if (jObject.Length > 0)
                    TestPropetries(type.GetElementType(), jObject[0]);
                else if (!IgnoreRequestWithBadData)
                    throw new NullReferenceException("Impossible to do test for this input data!");
            }
            else
                throw new InvalidCastException();
        }

        protected HashSet<string> GetPropertyNames(Type type)
        {
            var props = type.GetRuntimeProperties();
            var resp = new HashSet<string>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order != null)
                {
                    resp.Add(order.PropertyName);
                }
            }
            return resp;
        }

        protected void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        protected void WriteLine(JsonRpcResponse r)
        {
            if (r.IsError)
                Console.WriteLine(JsonConvert.SerializeObject(r.Error, Formatting.Indented));
            else
                Console.WriteLine(JsonConvert.SerializeObject(r.Result, Formatting.Indented));
        }
    }
}