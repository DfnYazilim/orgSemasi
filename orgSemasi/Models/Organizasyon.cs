namespace orgSemasi.Models
{
    public class Organizasyon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sirket Sirket { get; set; }
        public int SirketId { get; set; }
    }
}