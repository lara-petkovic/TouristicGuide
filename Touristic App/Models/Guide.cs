namespace Touristic_App.Models
{
    public class Guide
    {
        public long Id { get; set; }                  //Kad nisam imala ovo nisam mogla da scaffoldujem guidescontroller, zasto?
        public String Username { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int NumberOfLanguages { get; set; }
    }
}
