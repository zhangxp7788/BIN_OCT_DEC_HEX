using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIN_OCT_DEC_HEX.Servers;
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
            var bitType = Request.Form["bitType"].ToString();

            IConvertServer server = null;

            switch (bitType)
            {
                case "2":
                    server = new BINServer();
                    break;
                case "8":
                    server = new OCTServer();
                    break;
                case "10":
                    server = new DECServer();
                    break;
                case "16":
                    server = new HEXServer();
                    break;
                default:
                    break;
            }

            var res = new
            {
                BIN = await server.ToBIN(originalValue),
                OCT = await server.ToOCT(originalValue),
                DEC = await server.ToDEC(originalValue),
                HEX = await server.ToHEX(originalValue),
            };

            return Ok(res);
        }


    }
}