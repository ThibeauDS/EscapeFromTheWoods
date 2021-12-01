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
            Bos bos1 = BosBeheerder.GenereerBos(1, 1000, 1000, new List<string> { "Jerry", "Bart", "Monika", "Robin" });
            Bos bos2 = BosBeheerder.GenereerBos(2, 500, 500, new List<string> { "初音ミク", "鏡音リン", "鏡音レン", "巡音ルカ", "MEIKO", "KAITO" });
            Bos bos3 = BosBeheerder.GenereerBos(3, 750, 500, new List<string> { "Pol", "Pim", "Jan", "Kim", "Tim", "Raf", "Jos", "Rik", "Rob", "Ann" });
            Bos bos4 = BosBeheerder.GenereerBos(4, 800, 600, new List<string> { "Zuster Katharina", "Broeder Jakob", "Heilige Maria", "Goedele" });

            List<Task> tasks = new();
            tasks.Add(Task.Run(() => AapBeheerder.ProcessAap(bos1)));
            tasks.Add(Task.Run(() => AapBeheerder.ProcessAap(bos2)));
            tasks.Add(Task.Run(() => AapBeheerder.ProcessAap(bos3)));
            tasks.Add(Task.Run(() => AapBeheerder.ProcessAap(bos4)));
            Task.WaitAll(tasks.ToArray());

            ApplicatieBeheerder.GenereerDirectorys();

            List<Task> tasks1 = new();
            tasks1.Add(Task.Run(() => ApplicatieBeheerder.ProcessData(bos1)));
            tasks1.Add(Task.Run(() => ApplicatieBeheerder.ProcessData(bos2)));
            tasks1.Add(Task.Run(() => ApplicatieBeheerder.ProcessData(bos3)));
            tasks1.Add(Task.Run(() => ApplicatieBeheerder.ProcessData(bos4)));
            Task.WaitAll(tasks1.ToArray());
        }
    }
}
