
namespace MyCommerce.Model //modeli su view modeli ne entiteti iz baze
{
    public partial class Proizvodi
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Sifra { get; set; } = null!;
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[] Slika { get; set; } = null!;
        public byte[] SlikaThumb { get; set; } = null!;
        public bool? Status { get; set; } = null!;

        public string StateMachine { get; set; } = null!;
    }
}
