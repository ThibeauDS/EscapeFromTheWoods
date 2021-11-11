using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Klassen
{
    public class Aap
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        #endregion

        #region Constructors
        public Aap(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }
        #endregion
    }
}
