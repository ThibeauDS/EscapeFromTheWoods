namespace DomeinLaag.Klassen
{
    public class Bos
    {
        #region Properties
        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }
        #endregion

        #region Constructors
        public Bos(int xmin, int xmax, int ymin, int ymax)
        {
            Xmin = xmin;
            Xmax = xmax;
            Ymin = ymin;
            Ymax = ymax;
        }
        #endregion
    }
}
