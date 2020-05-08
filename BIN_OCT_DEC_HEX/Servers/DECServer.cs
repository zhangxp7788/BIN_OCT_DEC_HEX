using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public class DECServer : BaseServer
    {
        protected override int BitType => SystemConstant.DECType;

        protected override char[] charArray => SystemConstant.DECCharArray.ToCharArray();

        protected override async Task<string> ToBINDo(string originalValue)
        {
            return await DEC2Other(originalValue, EnumBitType.BINType);
        }

        protected override async Task<string> ToOCTDo(string originalValue)
        {
            return await DEC2Other(originalValue, EnumBitType.OCTType);
        }

        protected override async Task<string> ToDECDo(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }

        protected override async Task<string> ToHEXDo(string originalValue)
        {
            return await DEC2Other(originalValue, EnumBitType.HEXType);
        }
    }
}
