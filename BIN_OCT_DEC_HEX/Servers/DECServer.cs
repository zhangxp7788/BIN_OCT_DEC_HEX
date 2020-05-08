using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public class DECServer : BaseConvertServer
    {
        protected override char[] charArray => SystemConstant.DECCharArray.ToCharArray();

        protected override async Task<string> ToBINDo(string originalValue)
        {
            Func<int, char> func = intVaule => char.Parse(intVaule.ToString());
            return await ToConvert(originalValue, SystemConstant.BINType, func);
        }

        protected override async Task<string> ToOCTDo(string originalValue)
        {
            Func<int, char> func = intVaule => char.Parse(intVaule.ToString());
            return await ToConvert(originalValue, SystemConstant.OCTType, func);
        }

        protected override async Task<string> ToDECDo(string originalValue)
        {
            return await Task.FromResult(originalValue);
        }

        protected override async Task<string> ToHEXDo(string originalValue)
        {

            Func<int, char> func = intVaule =>
            {
                char quotientStr;
                switch (intVaule)
                {
                    case 10:
                        quotientStr = 'A';
                        break;
                    case 11:
                        quotientStr = 'B';
                        break;
                    case 12:
                        quotientStr = 'C';
                        break;
                    case 13:
                        quotientStr = 'D';
                        break;
                    case 14:
                        quotientStr = 'E';
                        break;
                    case 15:
                        quotientStr = 'F';
                        break;
                    default:
                        quotientStr = char.Parse(intVaule.ToString());
                        break;
                }
                return quotientStr;
            };
            return await ToConvert(originalValue, SystemConstant.HEXType, func);
        }


        protected virtual async Task<string> ToConvert(string originalValue, int bitType, Func<int, char> func)
        {
            var container = new BitContainer();
            var parseVal = int.Parse(originalValue);

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
                        char quotientStr = func(quotient);
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
