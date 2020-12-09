namespace orgSemasi.Models
{
    public class OfisLider
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public Ofis Ofis { get; set; }
        public int OfisId { get; set; }
    }
}