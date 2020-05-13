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
        protected override char[] CharArray => SystemConstant.DECCharArray.ToCharArray();

        protected override int BitType => SystemConstant.DECType;

        public override async Task<string> DEC2Self(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }

        public override async Task<string> Self2DEC(string originalValue)
        {
            return await Task.FromResult(originalValue); ;
        }

    }
}
