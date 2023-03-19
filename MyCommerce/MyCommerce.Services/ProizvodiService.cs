
using MyCommerce.Model;

namespace MyCommerce.Services
{
    public class ProizvodiService : IProizvodiService
    {
        List<Proizvodi> proizvodis = new List<Proizvodi> { new Proizvodi() {
        ProizvodId= 1,
        Naziv="Lapotop"
        } };


        public IList<Proizvodi> Get()
        {
            return proizvodis;
        }
    }
}
