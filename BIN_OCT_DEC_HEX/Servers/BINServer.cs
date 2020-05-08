﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{

    public class BINServer : BaseServer
    {

        protected override char[] charArray => SystemConstant.BINCharArray.ToCharArray();

        protected override int BitType => SystemConstant.BINType;

        protected override async Task<string> ToBINDo(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }
    }
}
