using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{

    public class BINServer : BaseServer
    {

        protected override char[] charArray => "01".ToCharArray();

        protected override int BitType => 2;

        protected override int CharToInt(char charVal)
        {
            return int.Parse(charVal.ToString());
        }

        protected override async Task<string> ToBINDo(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }
    }
}
