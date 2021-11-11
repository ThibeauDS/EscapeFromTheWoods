namespace DomeinLaag.Klassen
{
    public class Boom
    {
        #region Properties
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Constructors
        public Boom(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        #endregion
    }
}
