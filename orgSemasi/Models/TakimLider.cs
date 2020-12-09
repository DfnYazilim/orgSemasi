namespace orgSemasi.Models
{
    public class TakimLider
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public Takim Takim { get; set; }
        public int TakimId { get; set; }
    }
}