namespace orgSemasi.Models
{
    public class Takim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ofis Ofis { get; set; }
        public int OfisId { get; set; }
    }
}