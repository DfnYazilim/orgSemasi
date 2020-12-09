namespace orgSemasi.Models
{
    public class BolgeLider
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public Bolge Bolge { get; set; }
        public int BolgeId { get; set; }
    }
}