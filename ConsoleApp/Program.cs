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

            Bos bos = BosBeheerder.GenereerBos(1000);
            List<Boom> bomen = BoomBeheerder.GenereerBomen(bos, 1000);
            List<Aap> apen = AapBeheerder.GenereerApen(4, new List<string> { "Jerry", "Bart", "Monika", "Robin" });

            List<Task> tasks = new();
            tasks.Add(Task.Run(() => applicatieBeheerder.Process(bos, bomen, apen)));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
