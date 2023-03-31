
using Microsoft.EntityFrameworkCore;
using MyCommerce.Model.Requests;

namespace MyCommerce.Services.Interfaces
{
    public interface IKorisniciService
    {
        Task<List<Model.Korisnici>> Get();
        Model.Korisnici Insert(KorisniciInsertRequest request);
        Model.Korisnici Update(int id, KorisniciUpdateRequest request);//you should devide id from object, but not anything else
        Model.Korisnici Delete(int id);
    }
}
