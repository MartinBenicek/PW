using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class PacientInit
    {
        public IList<Pacient> GetPacients()
        {
            IList<Pacient> pacients = new List<Pacient>();

            pacients.Add(new Pacient()
            {
                Id = 1,
                UserRoleID = 1
            });
            pacients.Add(new Pacient()
            {
                Id = 2,
                UserRoleID = 2
            });

            return pacients;
        }
    }
}