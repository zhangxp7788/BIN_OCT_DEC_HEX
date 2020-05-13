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
            

            BaseServer server = null;

            switch (bitType)
            {
                case "2" :
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

            var decVaule = await server.Self2DEC(originalValue);

            var data = new
            {
                Bin = await new BINServer().DEC2Self(decVaule),
                OCT = await new OCTServer().DEC2Self(decVaule),
                DEC = await new DECServer().DEC2Self(decVaule),
                HEX = await new HEXServer().DEC2Self(decVaule),
            };

            return Ok(data);

        }

    }
}