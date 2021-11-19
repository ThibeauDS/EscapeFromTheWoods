using System.Collections.Generic;

namespace DomeinLaag.Klassen
{
    public class Bos
    {
        #region Properties
        public int Id { get; set; }
        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }
        public List<Boom> Bomen { get; set; }
        #endregion

        #region Constructors
        public Bos(int id, int xmin, int xmax, int ymin, int ymax)
        {
            Id = id;
            Xmin = xmin;
            Xmax = xmax;
            Ymin = ymin;
            Ymax = ymax;
        }
        #endregion
    }
}
