using DomeinLaag.Exceptions;
using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Beheerders
{
    public class AapBeheerder
    {
        public static List<Aap> GenereerApen(int aantal, List<string> namen)
        {
            try
            {
                List<Aap> apen = new();

                if (aantal > 4)
                {
                    throw new AapBeheerderException("Het aantal mag niet groter zijn dan 4.");
                }

                if (aantal > namen.Count)
                {
                    throw new AapBeheerderException("Het aantal kan niet groter zijn dan het aantal beschikbare namen.");
                }

                if (namen == null)
                {
                    throw new AapBeheerderException("Er moet minstens 1 naam zijn.");
                }

                for (int i = 0; i < aantal; i++)
                {
                    Aap aap = new(i + 1, namen[i]);
                    apen.Add(aap);
                }

                return apen;
            }
            catch (Exception ex)
            {
                throw new AapBeheerderException("GenereerApen is niet gelukt.", ex);
            }
        }
    }
}
