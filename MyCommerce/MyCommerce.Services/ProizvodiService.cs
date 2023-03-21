
using MyCommerce.Model;

namespace MyCommerce.Services
{
    public class ProizvodiService : IProizvodiService
    {
        List<Model.Proizvodi> proizvodis = new List<Model.Proizvodi> { new Model.Proizvodi() {
        ProizvodId= 1,
        Naziv="Lapotop"
        } };


        public IList<Model.Proizvodi> Get()
        {
            return proizvodis;
        }
    }
}
