using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public abstract class BaseServer : BaseConvertServer
    {
        protected abstract int BitType { get; }
        protected abstract int CharToInt(char charVal);

        protected override async Task<string> ToBINDo(string originalValue)
        {
            var decVal = await ToDECDo(originalValue);
            var decServer = new DECServer();
            return await decServer.ToBIN(decVal);
        }
        protected override async Task<string> ToOCTDo(string originalValue)
        {
            var decVal = await ToDECDo(originalValue);
            var decServer = new DECServer();
            return await decServer.ToOCT(decVal);
        }
        protected override async Task<string> ToDECDo(string originalValue)
        {
            var finalValue = 0;
            var charArray = originalValue.ToCharArray().Reverse().ToArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                var bitValue = CharToInt(charArray[i]);
                if (bitValue != 0)
                {
                    finalValue += bitValue * (int)Math.Pow(BitType, i);
                }
            }

            return await Task.FromResult(finalValue.ToString());
        }

        protected override async Task<string> ToHEXDo(string originalValue)
        {
            var decVal = await ToDECDo(originalValue);
            var decServer = new DECServer();
            return await decServer.ToHEX(decVal);
        }


    }
}
