using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{

    public abstract class BaseServer : BaseConvertServer
    {   

        protected abstract int BitType { get; }
        protected virtual int CharToInt(char charVal)
        {
            return int.Parse(charVal.ToString());
        }

        protected override async Task<string> ToBINDo(string originalValue)
        {
            var decVal = await ToDECDo(originalValue);
            return await DEC2Other(decVal, EnumBitType.BINType);
        }
        protected override async Task<string> ToOCTDo(string originalValue)
        {
            var decVal = await ToDECDo(originalValue);
            return await DEC2Other(decVal, EnumBitType.OCTType);
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
            return await DEC2Other(decVal, EnumBitType.HEXType);
        }

        protected async Task<string> DEC2Other(string originalValue, EnumBitType enumBit)
        {
            var container = new BitContainer();
            var parseVal = int.Parse(originalValue);
            var bitType = (byte)enumBit;

            //int32类型的整数,所以最大32位
            Recursion(parseVal, 32);

            void Recursion(int val, int maxI)
            {
                for (int i = 0; i < maxI; i++)
                {
                    //除数
                    var divisor = (int)Math.Pow(bitType, i);
                    //求商
                    var quotient = val / divisor;
                    if (quotient < bitType)
                    {
                        char quotientStr = IntToChar(quotient, enumBit);
                        container.Add(i, quotientStr);
                        //取模
                        var modulus = val % divisor;
                        Recursion(modulus, i);
                        return;
                    }
                }
            }

            return await Task.FromResult(container.ToString());
        }

        protected virtual char IntToChar(int charVal)
        {
            return char.Parse(charVal.ToString());
        }

        private char IntToChar(int charVal, EnumBitType enumBit)
        {
            if (enumBit == EnumBitType.HEXType)
            {
                // 这里要想办法优化
                return new HEXServer().IntToChar(charVal);
            }

            return IntToChar(charVal);
        }

        class BitContainer
        {
            private Dictionary<int, char> dic = new Dictionary<int, char>();
            internal void Add(int bit, char charValue)
            {
                dic.Add(bit, charValue);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();

                for (int i = 0; i < dic.Keys.Max() + 1; i++)
                {
                    if (dic.Keys.Contains(i))
                        sb.Append(dic[i]);
                    else
                        sb.Append('0');

                    if ((i + 1) % 4 == 0)
                        sb.Append(' ');
                }

                var charArray = sb.ToString().ToCharArray().Reverse().ToArray();
                return new string(charArray);
            }
        }

    }    
}
