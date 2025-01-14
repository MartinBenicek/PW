using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class ZpravaService : IZpravaService
    {
        private readonly NemocniceDbContext _context;

        public ZpravaService(NemocniceDbContext context)
        {
            _context = context;
        }

        public List<KartaLekarskaZprava> GetZpravy()
        {
            return (from karta in _context.Karta
                    join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                    select new KartaLekarskaZprava
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = lekarskaZprava.Id,
                            Zprava = lekarskaZprava.Zprava,
                            Datum = lekarskaZprava.Datum
                        }
                    }).ToList();
        }

        public List<KartaLekarskaZprava> SelectForUser(int userId)
        {
            return (from karta in _context.Karta
                    join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                    where karta.PacientID == userId
                    select new KartaLekarskaZprava
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = lekarskaZprava.Id,
                            Zprava = lekarskaZprava.Zprava,
                            Datum = lekarskaZprava.Datum
                        }
                    }).ToList();
        }

        public void DeleteZprava(int id)
        {
            var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == id);
            if (zprava != null)
            {
                _context.LekarskaZprava.Remove(zprava);
                _context.SaveChanges();
            }
        }

        public void CreateZprava(KartaLekarskaZprava viewModel)
        {
            var lekarskaZprava = new LekarskaZprava
            {
                Zprava = viewModel.LekarskaZprava.Zprava,
                Datum = viewModel.LekarskaZprava.Datum ?? DateTime.Now,
                KartaID = viewModel.Karta.KartaId
            };

            _context.LekarskaZprava.Add(lekarskaZprava);
            _context.SaveChanges();
        }

        public KartaLekarskaZprava GetZpravaById(int id)
        {
            return (from karta in _context.Karta
                    join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                    where lekarskaZprava.Id == id
                    select new KartaLekarskaZprava
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = lekarskaZprava.Id,
                            Zprava = lekarskaZprava.Zprava,
                            Datum = lekarskaZprava.Datum
                        }
                    }).FirstOrDefault();
        }

        public void UpdateZprava(KartaLekarskaZprava viewModel)
        {
            var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == viewModel.LekarskaZprava.LekarskaZpravaId);
            if (zprava != null)
            {
                zprava.Zprava = viewModel.LekarskaZprava.Zprava;
                zprava.Datum = viewModel.LekarskaZprava.Datum ?? DateTime.MinValue;
                zprava.KartaID = viewModel.Karta.KartaId;

                _context.LekarskaZprava.Update(zprava);
                _context.SaveChanges();
            }
        }
    }
}