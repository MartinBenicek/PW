using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class PredpisService : IPredpisService
    {
        private readonly NemocniceDbContext _context;

        public PredpisService(NemocniceDbContext context)
        {
            _context = context;
        }

        public List<LekarskaZpravaPredpisViewModel> GetPredpisy()
        {
            return (from predpis in _context.Predpis
                    join zprava in _context.LekarskaZprava on predpis.LekarskaZpravaID equals zprava.Id
                    select new LekarskaZpravaPredpisViewModel
                    {
                        Predpis = new PredpisViewModel
                        {
                            Id = predpis.Id,
                            TypLeku = predpis.TypLeku,
                            NazevLeku = predpis.NazevLeku,
                            CasPodani = predpis.CasPodani,
                            LekarskaZpravaId = predpis.LekarskaZpravaID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = zprava.Id,
                            Zprava = zprava.Zprava,
                            Datum = zprava.Datum,
                            KartaId = zprava.KartaID
                        }
                    }).ToList();
        }

        public List<LekarskaZpravaPredpisViewModel> SelectForUser(int userId)
        {
            return (from predpis in _context.Predpis
                    join zprava in _context.LekarskaZprava on predpis.LekarskaZpravaID equals zprava.Id
                    join karta in _context.Karta on zprava.KartaID equals karta.Id
                    where karta.PacientID == userId
                    select new LekarskaZpravaPredpisViewModel
                    {
                        Predpis = new PredpisViewModel
                        {
                            Id = predpis.Id,
                            TypLeku = predpis.TypLeku,
                            NazevLeku = predpis.NazevLeku,
                            CasPodani = predpis.CasPodani,
                            LekarskaZpravaId = predpis.LekarskaZpravaID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = zprava.Id,
                            Zprava = zprava.Zprava,
                            Datum = zprava.Datum,
                            KartaId = zprava.KartaID
                        }
                    }).ToList();
        }

        public List<LekarskaZpravaPredpisViewModel> SelectForDoctor(int doctorId)
        {
            return (from predpis in _context.Predpis
                    join zprava in _context.LekarskaZprava on predpis.LekarskaZpravaID equals zprava.Id
                    join ordinace in _context.Ordinace on zprava.KartaID equals ordinace.Id
                    where ordinace.DoktorID == doctorId
                    select new LekarskaZpravaPredpisViewModel
                    {
                        Predpis = new PredpisViewModel
                        {
                            Id = predpis.Id,
                            TypLeku = predpis.TypLeku,
                            NazevLeku = predpis.NazevLeku,
                            CasPodani = predpis.CasPodani,
                            LekarskaZpravaId = predpis.LekarskaZpravaID
                        },
                        LekarskaZprava = new LekarskaZpravaViewModel
                        {
                            LekarskaZpravaId = zprava.Id,
                            Zprava = zprava.Zprava,
                            Datum = zprava.Datum,
                            KartaId = zprava.KartaID
                        }
                    }).ToList();
        }

        public void DeletePredpis(int id)
        {
            var predpis = _context.Predpis.FirstOrDefault(p => p.Id == id);
            if (predpis != null)
            {
                _context.Predpis.Remove(predpis);
                _context.SaveChanges();
            }
        }

        public void CreatePredpis(PredpisViewModel viewModel)
        {
            var predpis = new Predpis
            {
                TypLeku = viewModel.TypLeku,
                NazevLeku = viewModel.NazevLeku,
                CasPodani = viewModel.CasPodani,
                LekarskaZpravaID = viewModel.LekarskaZpravaId
            };

            _context.Predpis.Add(predpis);
            _context.SaveChanges();
        }

        public PredpisViewModel GetPredpisById(int id)
        {
            return _context.Predpis.Where(p => p.Id == id).Select(p => new PredpisViewModel
            {
                Id = p.Id,
                TypLeku = p.TypLeku,
                NazevLeku = p.NazevLeku,
                CasPodani = p.CasPodani,
                LekarskaZpravaId = p.LekarskaZpravaID
            }).FirstOrDefault();
        }

        public void UpdatePredpis(PredpisViewModel viewModel)
        {
            var predpis = _context.Predpis.FirstOrDefault(p => p.Id == viewModel.Id);
            if (predpis != null)
            {
                predpis.TypLeku = viewModel.TypLeku;
                predpis.NazevLeku = viewModel.NazevLeku;
                predpis.CasPodani = viewModel.CasPodani;
                predpis.LekarskaZpravaID = viewModel.LekarskaZpravaId;

                _context.Predpis.Update(predpis);
                _context.SaveChanges();
            }
        }
    }
}