using Nemocnice.domain;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class DoktorInit
    {
        public IList<Doktor> GetDoktors()
        {
            IList<Doktor> doktors = new List<Doktor>();

            doktors.Add(new Doktor()
            {
                Id = 1,
                TitulID = 1,
                UserRoleID = 3,
            });

            return doktors;
        }
    }
}