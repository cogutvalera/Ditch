﻿using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_key_references()
        {
            var pubKey = new PublicKeyType(Config.SteemAddressPrefix + "6C8GjDBAHrfSqaNRn4FnLLUdCfw3WgjY3td1cC4T7CKpb32YM6");

            var args = new GetKeyReferencesArgs
            {
                Keys = new[] { pubKey }
            };
            var resp = await Api.GetKeyReferences(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
