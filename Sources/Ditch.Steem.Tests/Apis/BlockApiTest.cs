using System.Threading;
using System.Threading.Tasks;
using Ditch.Steem.Models;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class BlockApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_block_header()
        {
            var args = new GetBlockHeaderArgs
            {
                BlockNum = 1
            };
            var resp = await Api.GetBlockHeader(args, CancellationToken.None);
            TestPropetries(resp);
        }
        
        [Test][Parallelizable]
        public async Task get_block()
        {
            var args = new GetBlockArgs
            {
                BlockNum = 1
            };
            var resp = await Api.GetBlock(args, CancellationToken.None);
            TestPropetries(resp);
        }
    }
}
