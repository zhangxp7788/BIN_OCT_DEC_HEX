using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BIN_OCT_DEC_HEX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        [HttpPost("convert")]
        public async Task<IActionResult> ValueConvert()
        {

            var originalValue = Request.Form["originalValue"];
            var bitType = Request.Form["bitType"];

            var value = "01000111000";

            var res = new
            {
                BIN = 000,
                OCT = 1411,
                DEC = await BIN2DEC(value),
                HEX = "12ABC",
            };

            return Ok(res);
        }

        private async Task<string> BIN2DEC(string originalValue)
        {
            if (!IsBIN(originalValue))
                return await Task.FromResult("值无效");


            var finalValue = 0;
            char[] charArray = originalValue.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 1)
                {
                    finalValue += 2 ^ i;
                }
            }

            return await Task.FromResult(finalValue.ToString());
        }

        /// <summary>
        /// 是否是二进制数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsBIN(string value)
        {
            foreach (var s in value)
            {
                if (s == '0' || s == '1')
                    continue;
                return false;
            }
            return true;
        }

    }
}