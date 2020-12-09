namespace orgSemasi.Models
{
    public class SirketLider
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public Sirket Sirket { get; set; }
        public int SirketId { get; set; }
    }
}