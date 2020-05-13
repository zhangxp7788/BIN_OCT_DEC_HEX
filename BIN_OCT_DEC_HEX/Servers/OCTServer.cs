using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public class OCTServer : BaseServer
    {
        protected override char[] CharArray => SystemConstant.OCTCharArray.ToCharArray();

        protected override int BitType => SystemConstant.OCTType;

    }
}
