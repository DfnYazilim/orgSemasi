namespace orgSemasi.Models
{
    public class Bolge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Organizasyon Organizasyon { get; set; }
        public int OrganizasyonId { get; set; }
    }
}