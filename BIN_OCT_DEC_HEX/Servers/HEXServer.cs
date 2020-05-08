using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public class HEXServer : BaseServer
    {
        protected override char[] charArray => SystemConstant.HEXCharArray.ToCharArray();

        protected override int BitType => SystemConstant.HEXType;

        protected override int CharToInt(char charVal)
        {
            var bitValue = 0;
            switch (charVal)
            {
                case 'A':
                case 'a':
                    bitValue = 10;
                    break;
                case 'B':
                case 'b':
                    bitValue = 11;
                    break;
                case 'C':
                case 'c':
                    bitValue = 12;
                    break;
                case 'D':
                case 'd':
                    bitValue = 13;
                    break;
                case 'E':
                case 'e':
                    bitValue = 14;
                    break;
                case 'F':
                case 'f':
                    bitValue = 15;
                    break;
                default:
                    bitValue = int.Parse(charVal.ToString());
                    break;
            }

            return bitValue;
        }

        protected override async Task<string> ToHEXDo(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }

    }
}
