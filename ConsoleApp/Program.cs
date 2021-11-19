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

            Bos bos1 = BosBeheerder.GenereerBos(1, 1000);
            bos1.Bomen = BoomBeheerder.GenereerBomen(bos1, 1000);

            Bos bos2 = BosBeheerder.GenereerBos(2, 500);
            bos2.Bomen = BoomBeheerder.GenereerBomen(bos2, 500);

            Bos bos3 = BosBeheerder.GenereerBos(3, 750);
            bos3.Bomen = BoomBeheerder.GenereerBomen(bos3, 500);

            Bos bos4 = BosBeheerder.GenereerBos(4, 800);
            bos4.Bomen = BoomBeheerder.GenereerBomen(bos4, 600);

            List<Aap> apen = AapBeheerder.GenereerApen(4, new List<string> { "Jerry", "Bart", "Monika", "Robin" });

            List<Task> tasks = new();
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos1, apen)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos2, apen)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos3, apen)));
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos4, apen)));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
