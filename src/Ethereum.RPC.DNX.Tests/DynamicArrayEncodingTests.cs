using System.Collections.Generic;
using Ethereum.RPC.ABI;
using Ethereum.RPC.Util;
using Xunit;

namespace Ethereum.ABI.Tests.DNX
{
    public class DynamicArrayEncodingTests
    {
        [Fact]
        public virtual void ShouldEncodeDynamicIntArray()
        {
            //Given
            var array = new uint[20];
            for (uint i = 0; i < 20; i++)
            {
                array[i] = i + 234567;
            }

            var listArray = new List<uint>(array);

            var arrayType = ArrayType.CreateABIType("uint[]");

            //when
            var result = arrayType.Encode(listArray).ToHexString();

            //then
            //starts at 2 0000000000000000000000000000000000000000000000000000000000000020;
            var expected = "0000000000000000000000000000000000000000000000000000000000000014000000000000000000000000000000000000000000000000000000000003944700000000000000000000000000000000000000000000000000000000000394480000000000000000000000000000000000000000000000000000000000039449000000000000000000000000000000000000000000000000000000000003944a000000000000000000000000000000000000000000000000000000000003944b000000000000000000000000000000000000000000000000000000000003944c000000000000000000000000000000000000000000000000000000000003944d000000000000000000000000000000000000000000000000000000000003944e000000000000000000000000000000000000000000000000000000000003944f0000000000000000000000000000000000000000000000000000000000039450000000000000000000000000000000000000000000000000000000000003945100000000000000000000000000000000000000000000000000000000000394520000000000000000000000000000000000000000000000000000000000039453000000000000000000000000000000000000000000000000000000000003945400000000000000000000000000000000000000000000000000000000000394550000000000000000000000000000000000000000000000000000000000039456000000000000000000000000000000000000000000000000000000000003945700000000000000000000000000000000000000000000000000000000000394580000000000000000000000000000000000000000000000000000000000039459000000000000000000000000000000000000000000000000000000000003945a";

            Assert.Equal(expected, result);
        }

    }
}