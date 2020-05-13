using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIN_OCT_DEC_HEX.Servers
{
    public abstract class BaseServer
    {
        protected abstract char[] CharArray { get; }
        protected abstract int BitType { get; }
        protected virtual int CharToInt(char charVal)
        {
            return int.Parse(charVal.ToString());
        }
        protected virtual char IntToChar(int charVal)
        {
            return char.Parse(charVal.ToString());
        }

        public virtual async Task<string> Self2DEC(string originalValue)
        {
            if (IsValid(originalValue, CharArray) == false) return "值无效";

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

        public virtual async Task<string> DEC2Self(string originalValue)
        {
            if (IsValid(originalValue, SystemConstant.DECCharArray.ToCharArray()) == false) return "值无效";

            var container = new BitContainer();
            var parseVal = int.Parse(originalValue);

            //int32类型的整数,所以最大32位
            Recursion(parseVal, 64);

            void Recursion(int val, int maxI)
            {
                for (int i = 0; i < maxI; i++)
                {
                    //除数
                    var divisor = (int)Math.Pow(BitType, i);
                    //求商
                    var quotient = val / divisor;
                    if (quotient < BitType)
                    {
                        char quotientStr = IntToChar(quotient);
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

        /// <summary>
        /// 判断值是否有效
        /// </summary>
        private bool IsValid(string val, char[] charArray)
        {
            foreach (var s in val)
            {
                if (charArray.Any(e => e == s))
                    continue;
                return false;
            }
            return true;
        }
    }
}
