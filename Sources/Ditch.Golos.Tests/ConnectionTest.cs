﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Golos.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        private HttpManager HttpManager;

        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            WebSocketManager = new WebSocketManager();
            HttpManager = new HttpManager();
        }

        [Ignore("LongRuningTest")]
        [Test]
        [TestCase("wss://ws.golos.io")]
        [TestCase("wss://ws.testnet.golos.io")]
        [TestCase("wss://golosd.steepshot.org")]
        public async Task NodeTest(string url)
        {
            var manager = new OperationManager(WebSocketManager);

            var sw = new Stopwatch();
            sw.Start();
            if (manager.ConnectTo(url, CancellationToken.None))
            {
                var hfvr = await manager.GetConfig<JObject>(CancellationToken.None);
                if (hfvr.IsError)
                    WriteLine(hfvr);
                Assert.IsFalse(hfvr.IsError);
                JToken version;
                if (!hfvr.Result.TryGetValue("STEEM_BLOCKCHAIN_VERSION", out version))
                    if (!hfvr.Result.TryGetValue("STEEMIT_BLOCKCHAIN_VERSION", out version))
                        Assert.Fail();
                WriteLine(version.Value<string>());
            }
            sw.Stop();

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected);
        }

        [Ignore("LongRuningTest")]
        [Test]
        [TestCase("https://public-ws.golos.io")]
        [TestCase("https://golosd.steepshot.org")]
        public async Task HttpsNodeTest(string url)
        {
            var manager = new OperationManager(HttpManager);

            var sw = new Stopwatch();
            sw.Start();
            if (manager.ConnectTo(url, CancellationToken.None))
            {
                var hfvr = await manager.GetConfig<JObject>(CancellationToken.None);
                if (hfvr.IsError)
                    WriteLine(hfvr);
                Assert.IsFalse(hfvr.IsError);
                JToken version;
                if (!hfvr.Result.TryGetValue("STEEM_BLOCKCHAIN_VERSION", out version))
                    if (!hfvr.Result.TryGetValue("STEEMIT_BLOCKCHAIN_VERSION", out version))
                        Assert.Fail();
                WriteLine(version.Value<string>());
            }
            sw.Stop();

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected);
        }
    }
}
