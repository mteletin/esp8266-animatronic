using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esp8266_Animatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Screen canvas = Screen.Init();
        Random r = new Random();
        StringBuilder output = new StringBuilder("");
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            canvas.Canvas = new int[65, 48];
            output.Clear();

            Fonts.PrintSymbol(24, 0, 0);
            Fonts.PrintSymbol(23, 8, 0);
            Fonts.PrintSymbol(23, 16, 0);
            Fonts.PrintSymbol(23, 24, 0);
            Fonts.PrintSymbol(23, 32, 0);
            Fonts.PrintSymbol(23, 40, 0);
            Fonts.PrintSymbol(23, 48, 0);
            Fonts.PrintSymbol(25, 56, 0);

            Fonts.PrintSymbol(22,  0,  8);
            Fonts.PrintSymbol(255, 8, 8);
            Fonts.PrintSymbol('2', 16, 8);
            Fonts.PrintSymbol('0', 24, 8);
            Fonts.PrintSymbol('2', 32, 8);
            Fonts.PrintSymbol('2', 40, 8);
            Fonts.PrintSymbol(255, 48, 8);
            Fonts.PrintSymbol(22,  56, 8);

            Fonts.PrintSymbol(22,   0, 16);
            Fonts.PrintSymbol(215,  8, 16);
            Fonts.PrintSymbol(215, 16, 16);
            Fonts.PrintSymbol(215, 24, 16);
            Fonts.PrintSymbol(215, 32, 16);
            Fonts.PrintSymbol(215, 40, 16);
            Fonts.PrintSymbol(215, 48, 16);
            Fonts.PrintSymbol(22,  56, 16);

            Fonts.PrintSymbol(22, 0, 24);
            Fonts.PrintSymbol(22, 56, 24);

            Fonts.PrintSymbol(22, 0, 32);
            Fonts.PrintSymbol(22, 56, 32);

            Fonts.PrintSymbol(26,  0, 40);
            Fonts.PrintSymbol(23,  8, 40);
            Fonts.PrintSymbol(23, 16, 40);
            Fonts.PrintSymbol(23, 24, 40);
            Fonts.PrintSymbol(23, 32, 40);
            Fonts.PrintSymbol(23, 40, 40);
            Fonts.PrintSymbol(23, 48, 40);
            Fonts.PrintSymbol(27, 56, 40);

            for (int x = 0; x < 64; x++)
            {
                canvas.stars[x] += canvas.dx_stars[x] * 2; if (canvas.stars[x] > 47) canvas.stars[x] = 0;
                canvas.Canvas[x, (int)canvas.stars[x]] = 1;
            }

            for (int x = 0; x < 64; x++)
            {
                int yy1 = (int)Math.Round(Math.Sin(canvas.xx[0]) * 23 + 24);
                int yy2 = (int)Math.Round(Math.Sin(canvas.xx[1]) * 18 + Math.Sin(canvas.xx[5]) * 5 + 24);
                int yy3 = (int)Math.Round(Math.Sin(canvas.xx[2]) * 10 + Math.Sin(canvas.xx[5]) * 13 + 24);
                int yy4 = (int)Math.Round(Math.Sin(canvas.xx[3]) * 8 + Math.Sin(canvas.xx[5]) * 15 + 24);
                int yy5 = (int)Math.Round(Math.Sin(canvas.xx[4]) * 6 + Math.Sin(canvas.xx[5]) * 17 + 24);
                //canvas.xx[0] += 256 / Math.PI;
                //canvas.xx[1] += 256.001 / Math.PI;
                //canvas.xx[2] += 256.002 / Math.PI;
                canvas.xx[3] += 256.003 / Math.PI;
                canvas.xx[4] += 256.004 / Math.PI;
                canvas.xx[5] += 0.001;
                //canvas.Canvas[x, yy1] = 1;
                //canvas.Canvas[x, yy2] = 1;
                //canvas.Canvas[x, yy3] = 1;
                canvas.Canvas[x, yy4] = 1;
                canvas.Canvas[x, yy5] = 1;
            }
            for (int y = 0; y < 48; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    output.Append(canvas.Canvas[x, y] == 1 ? "*" : ".");
                }
                output.Append(" ");
            }
            return output.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
