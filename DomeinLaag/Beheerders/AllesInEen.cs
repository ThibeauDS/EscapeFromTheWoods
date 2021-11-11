using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Beheerders
{
    public class AllesInEen
    {
        #region Methods
        public static List<Boom> GenereerBomen(Bos bos, int aantal)
        {
            //TODO: Hoe bomen automatisch laten genereren
            Random r = new Random();
            List<Boom> bomen = new();
            int huidigeBoom = 1;

            while (huidigeBoom <= aantal)
            {
                Boom boom = new(huidigeBoom, r.Next(bos.Xmin, bos.Xmax), r.Next(bos.Ymin, bos.Ymax));
                foreach (Boom b in bomen)
                {
                    if (b.X != boom.X && b.Y != boom.Y)
                    {
                        bomen.Add(boom);
                        huidigeBoom++;
                    }
                    break;
                }
                Console.WriteLine(boom.ToString());
            }

            return bomen;
        }
        #endregion
    }
}
