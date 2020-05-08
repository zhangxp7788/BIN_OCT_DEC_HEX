using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public abstract class BaseConvertServer : IConvertServer
    {
        abstract protected char[] charArray { get; }

        /// <summary>
        /// 判断值是否有效
        /// </summary>
        private bool IsValid(string val)
        {
            foreach (var s in val)
            {
                if (charArray.Any(e => e == s))
                    continue;
                return false;
            }
            return true;
        }
        
        public async Task<string> ToBIN(string originalValue)
        {
            if (!IsValid(originalValue))
                return await Task.FromResult("值无效");

            return await ToBINDo(originalValue);
        }

        public async Task<string> ToOCT(string originalValue)
        {
            if (!IsValid(originalValue))
                return await Task.FromResult("值无效");

            return await ToOCTDo(originalValue);
        }

        public async Task<string> ToDEC(string originalValue)
        {
            if (!IsValid(originalValue))
                return await Task.FromResult("值无效");

            return await ToDECDo(originalValue);
        }

        public async Task<string> ToHEX(string originalValue)
        {
            if (!IsValid(originalValue))
                return await Task.FromResult("值无效");

            return await ToHEXDo(originalValue);
        }


        protected abstract Task<string> ToBINDo(string originalValue);
        protected abstract Task<string> ToOCTDo(string originalValue);
        protected abstract Task<string> ToDECDo(string originalValue);
        protected abstract Task<string> ToHEXDo(string originalValue);


    }
}
