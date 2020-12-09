namespace orgSemasi.Models
{
    public class OrganizasyonLider
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public Organizasyon Organizasyon { get; set; }
        public int OrganizasyonId { get; set; }
    }
}