using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esp8266_Animatron.Controllers
{
    public class Screen
    {
        public int[,] Canvas { get; set; }
        public double[] xx = new double[6];
        public double[] stars = new double[64];
        public double[] dx_stars = new double[64];

        static Screen _screen = null;
        public static Screen Init()
        {
            if (_screen == null)
            {
                Random r = new Random();
                _screen = new Screen()
                {
                    Canvas = new int[65, 48]
                };
                for (int y = 0; y < 64; y++)
                {
                    _screen.dx_stars[y] = r.NextDouble();
                }
            }
            return _screen;
        }

    }
}
