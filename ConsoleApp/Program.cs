using DomeinLaag.Beheerders;
using DomeinLaag.Klassen;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Bos bos = new(0, 1000, 0, 1000);
            List<Boom> bomen = AllesInEen.GenereerBomen(bos, 1000);
        }
    }
}
