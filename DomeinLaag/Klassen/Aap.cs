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
