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

            if (namen != null && aantal <= namen.Count)
            {
                for (int i = 0; i < aantal; i++)
                {
                    Aap aap = new(i + 1, namen[i]);
                    apen.Add(aap);
                }
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
