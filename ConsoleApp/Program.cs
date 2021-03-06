using DataLaag.ADO;
using DomeinLaag.Beheerders;
using DomeinLaag.Interfaces;
using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        #region Properties
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EscapeFromTheWoodsDb"].ConnectionString;
        private readonly static ApplicatieBeheerder _applicatieBeheerder = new(new ApplicationRepository(_connectionString));
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Start applicatie");
            Stopwatch stopwatch = new();
            stopwatch.Start();
            Bos bos1 = BosBeheerder.GenereerBos(1, 1000, 1000, new List<string> { "Jerry", "Bart", "Monika", "Robin" });
            Bos bos2 = BosBeheerder.GenereerBos(2, 500, 500, new List<string> { "初音ミク", "鏡音リン", "鏡音レン", "巡音ルカ", "MEIKO", "KAITO" });
            Bos bos3 = BosBeheerder.GenereerBos(3, 750, 500, new List<string> { "Pol", "Pim", "Jan", "Kim", "Tim", "Raf", "Jos", "Rik", "Rob", "Ann" });
            Bos bos4 = BosBeheerder.GenereerBos(4, 800, 600, new List<string> { "Zuster Katharina", "Broeder Jakob", "Heilige Maria", "Goedele" });

            Console.WriteLine("Start - Genereer mappensctructuur");
            _applicatieBeheerder.GenereerDirectorys();
            Console.WriteLine("Einde - Genereer mappensctructuur");

            //Old Time: 00:00:01.3...
            //Console.WriteLine("Start - ProcessAap");
            //List<Task> tasks = new();
            //tasks.Add(AapBeheerder.ProcessAap(bos1));
            //tasks.Add(AapBeheerder.ProcessAap(bos2));
            //tasks.Add(AapBeheerder.ProcessAap(bos3));
            //tasks.Add(AapBeheerder.ProcessAap(bos4));
            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine("Einde - ProcessAap");

            //Console.WriteLine("Start - ProcessData");
            //List<Task> tasks1 = new();
            //tasks1.Add(_applicatieBeheerder.ProcessData(bos1));
            //tasks1.Add(_applicatieBeheerder.ProcessData(bos2));
            //tasks1.Add(_applicatieBeheerder.ProcessData(bos3));
            //tasks1.Add(_applicatieBeheerder.ProcessData(bos4));
            //Task.WaitAll(tasks1.ToArray());
            //Console.WriteLine("Einde - ProcessData");

            //Time: 00:00:00.6...
            List<Task> tasks1 = new();
            tasks1.Add(Task.Run(() => _applicatieBeheerder.Process(bos1)));
            tasks1.Add(Task.Run(() => _applicatieBeheerder.Process(bos2)));
            tasks1.Add(Task.Run(() => _applicatieBeheerder.Process(bos3)));
            tasks1.Add(Task.Run(() => _applicatieBeheerder.Process(bos4)));
            Task.WaitAll(tasks1.ToArray());
            stopwatch.Stop();
            Console.WriteLine($"Einde applicatie - {stopwatch.Elapsed}");
        }
    }
}
