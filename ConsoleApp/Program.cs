using DomeinLaag.Beheerders;
using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplicatieBeheerder applicatieBeheerder = new();

            List<Aap> apen1 = AapBeheerder.GenereerApen(4, new List<string> { "Jerry", "Bart", "Monika", "Robin" });
            Bos bos1 = BosBeheerder.GenereerBos(1, 1000);
            bos1.Bomen = BoomBeheerder.GenereerBomen(bos1, 1000);
            Boom.ZetAapInBoom(apen1, bos1.Bomen);

            List<Aap> apen2 = AapBeheerder.GenereerApen(4, new List<string> { "Maurice", "Pascale", "Robert", "Janinne" });
            Bos bos2 = BosBeheerder.GenereerBos(2, 500);
            bos2.Bomen = BoomBeheerder.GenereerBomen(bos2, 500);
            Boom.ZetAapInBoom(apen2, bos2.Bomen);

            List<Aap> apen3 = AapBeheerder.GenereerApen(4, new List<string> { "Pol", "Pim", "Jan", "Kim" });
            Bos bos3 = BosBeheerder.GenereerBos(3, 750);
            bos3.Bomen = BoomBeheerder.GenereerBomen(bos3, 500);
            Boom.ZetAapInBoom(apen3, bos3.Bomen);

            List<Aap> apen4 = AapBeheerder.GenereerApen(4, new List<string> { "Zuster Katharina", "Broeder Jakob", "Heilige Maria", "Goedele" });
            Bos bos4 = BosBeheerder.GenereerBos(4, 800);
            bos4.Bomen = BoomBeheerder.GenereerBomen(bos4, 600);
            Boom.ZetAapInBoom(apen4, bos4.Bomen);

            List<Task> tasks = new();
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos1, apen1)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos2, apen2)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos3, apen3)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos4, apen4)));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
