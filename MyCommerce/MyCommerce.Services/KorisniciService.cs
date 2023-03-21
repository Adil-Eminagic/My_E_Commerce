

using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MyCommerce.Model.Requests;
using MyCommerce.Services.Database;
using System.Security.Cryptography;
using System.Text;

namespace MyCommerce.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly EProdajaContext Context;
        private readonly IMapper Mapper;

        public KorisniciService(EProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public List<Model.Korisnici> Get()
        {
            var entities = Context.Korisnicis.ToList();

            var dto = Mapper.Map<List<Model.Korisnici>>(entities);

            return dto;

        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            var korisnik = Mapper.Map<Database.Korisnici>(request);

            var salt = GenerateSalt();
            var hash=GenerateHash(request.Password, salt);

            korisnik.LozinkaSalt = salt.ToString()!;
            korisnik.LozinkaHash= hash;

            Context.Korisnicis.Add(korisnik);
            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(korisnik);
        }

        private string GenerateSalt()
        {
            var salt = RandomNumberGenerator.GetBytes(128 / 8);
            return salt.ToString()!;
        }

        private string GenerateHash(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: Encoding.UTF8.GetBytes(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var korisnik = Context.Korisnicis.Find(id);
            Mapper.Map(request, korisnik);

            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(korisnik);
        }

        public Model.Korisnici Delete(int id)
        {
            var korisnik = Context.Korisnicis.Find(id);
            if (korisnik != null)
            {
                Context.Korisnicis.Remove(korisnik);
                Context.SaveChanges();
                return Mapper.Map<Model.Korisnici>(korisnik);
            }
            else
                return new Model.Korisnici();
           
        }
    }
}
