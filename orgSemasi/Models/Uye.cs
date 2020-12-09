namespace orgSemasi.Models
{
    public class Uye
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Takim Takim { get; set; }
        public int TakimId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
    }
}