using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Beheerders
{
    public class BosBeheerder
    {
        public static Bos GenereerBos(int id, int size)
        {
            return new Bos(id, 0, size, 0, size);
        }
        public static Bos GenereerBos(int id, int width, int height)
        {
            return new Bos(id, 0, width, 0, height);
        }
    }
}
