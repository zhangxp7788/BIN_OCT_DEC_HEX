using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public interface IConvertServer
    {
        Task<string> ToBIN(string originalValue);
        Task<string> ToOCT(string originalValue);
        Task<string> ToDEC(string originalValue);
        Task<string> ToHEX(string originalValue);        
    }
}
