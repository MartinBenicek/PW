using Nemocnice.domain; 

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class UserInit
    {
        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                Jmeno = "Marie",
                Prijmeni = "Kuèerová",
                Email = "marie.kucerova@example.com",
                Telefon = "123456789",
                Heslo = "securepassword",
                DatumNarozeni = new DateTime(1980, 1, 15)
            });
            users.Add(new User()
            {
                Id = 2,
                Jmeno = "Jakub",
                Prijmeni = "Malý",
                Email = "jakub.maly@example.com",
                Telefon = "987654321",
                Heslo = "securepassword",
                DatumNarozeni = new DateTime(1985, 6, 25)
            });
            users.Add(new User()
            {
                Id = 3,
                Jmeno = "Marie",
                Prijmeni = "Nováková",
                Email = "marie.novakova@example.com",
                Telefon = "987654321",
                Heslo = "securepassword",
                DatumNarozeni = new DateTime(1989, 5, 25)
            });
            users.Add(new User()
            {
                Id = 4,
                Jmeno = "Martin",
                Prijmeni = "Bzducha",
                Email = "martin.bzducha@example.com",
                Telefon = "987654321",
                Heslo = "securepassword",
                DatumNarozeni = new DateTime(2001, 4, 22)
            });
            
            return users;
        }
    }
}