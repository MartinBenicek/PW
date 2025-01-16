using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class ProhlidkyService : IProhlidkyService
    {
        private readonly NemocniceDbContext _context;

        public ProhlidkyService(NemocniceDbContext context)
        {
            _context = context;
        }

        public List<ProhlidkyViewModel> GetProhlidky()
        {
            return (from karta in _context.Karta
                    join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                    join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                    select new ProhlidkyViewModel
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskeSluzby = new LekarskeSluzbyViewModel
                        {
                            LekarskeSluzbyId = sluzby.Id,
                            Ukon = sluzby.Ukon,
                            Vysetreni = sluzby.Vysetreni,
                            Ockovani = sluzby.Ockovani,
                            Datum = sluzby.Datum
                        },
                        Ordinace = new OrdinaceViewModel
                        {
                            OrdinaceId = ordinace.Id,
                            Budova = ordinace.Budova,
                            Mistnost = ordinace.Mistnost,
                            DoktorId = ordinace.DoktorID,
                            ImageSrc = ordinace.ImageSrc
                        },
                        OrdinaceImageSrc = ordinace.ImageSrc
                    }).ToList();
        }

        public List<ProhlidkyViewModel> SelectForUser(int userId)
        {
            return (from karta in _context.Karta
                    join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                    join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                    where karta.PacientID == userId
                    select new ProhlidkyViewModel
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskeSluzby = new LekarskeSluzbyViewModel
                        {
                            LekarskeSluzbyId = sluzby.Id,
                            Ukon = sluzby.Ukon,
                            Vysetreni = sluzby.Vysetreni,
                            Ockovani = sluzby.Ockovani,
                            Datum = sluzby.Datum
                        },
                        Ordinace = new OrdinaceViewModel
                        {
                            OrdinaceId = ordinace.Id,
                            Budova = ordinace.Budova,
                            Mistnost = ordinace.Mistnost,
                            DoktorId = ordinace.DoktorID
                        }
                    }).ToList();
        }

        public List<ProhlidkyViewModel> SelectForDoctor(int doctorId)
        {
            return (from karta in _context.Karta
                    join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                    join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                    where ordinace.DoktorID == doctorId
                    select new ProhlidkyViewModel
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskeSluzby = new LekarskeSluzbyViewModel
                        {
                            LekarskeSluzbyId = sluzby.Id,
                            Ukon = sluzby.Ukon,
                            Vysetreni = sluzby.Vysetreni,
                            Ockovani = sluzby.Ockovani,
                            Datum = sluzby.Datum
                        },
                        Ordinace = new OrdinaceViewModel
                        {
                            OrdinaceId = ordinace.Id,
                            Budova = ordinace.Budova,
                            Mistnost = ordinace.Mistnost,
                            DoktorId = ordinace.DoktorID
                        }
                    }).ToList();
        }

        public void DeleteProhlidka(int id)
        {
            var sluzba = _context.LekarskeSluzby.FirstOrDefault(lz => lz.Id == id);
            if (sluzba != null)
            {
                _context.LekarskeSluzby.Remove(sluzba);
                _context.SaveChanges();
            }
        }

        public void CreateProhlidka(ProhlidkyViewModel viewModel)
        {
            try
            {
                Console.WriteLine("Creating new LekarskeSluzby");
                Console.WriteLine($"KartaID: {viewModel.Karta.KartaId}, OrdinaceID: {viewModel.Ordinace.OrdinaceId}, Ukon: {viewModel.LekarskeSluzby.Ukon}, Vysetreni: {viewModel.LekarskeSluzby.Vysetreni}, Ockovani: {viewModel.LekarskeSluzby.Ockovani}, Datum: {viewModel.LekarskeSluzby.Datum}");

                var lekarskeSluzby = new LekarskeSluzby
                {
                    KartaID = viewModel.Karta.KartaId,
                    OrdinaceID = viewModel.Ordinace.OrdinaceId,
                    Ukon = viewModel.LekarskeSluzby.Ukon ?? string.Empty,
                    Vysetreni = viewModel.LekarskeSluzby.Vysetreni ?? string.Empty,
                    Ockovani = viewModel.LekarskeSluzby.Ockovani ?? string.Empty,
                    Datum = viewModel.LekarskeSluzby.Datum
                };

                _context.LekarskeSluzby.Add(lekarskeSluzby);
                _context.SaveChanges();
                Console.WriteLine("LekarskeSluzby created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }


        public ProhlidkyViewModel GetProhlidkaById(int id)
        {
            return (from karta in _context.Karta
                    join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                    join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                    where sluzby.Id == id
                    select new ProhlidkyViewModel
                    {
                        Karta = new KartaViewModel
                        {
                            KartaId = karta.Id,
                            PacientId = karta.PacientID
                        },
                        LekarskeSluzby = new LekarskeSluzbyViewModel
                        {
                            LekarskeSluzbyId = sluzby.Id,
                            Ukon = sluzby.Ukon,
                            Vysetreni = sluzby.Vysetreni,
                            Ockovani = sluzby.Ockovani,
                            Datum = sluzby.Datum
                        },
                        Ordinace = new OrdinaceViewModel
                        {
                            OrdinaceId = ordinace.Id,
                            Budova = ordinace.Budova,
                            Mistnost = ordinace.Mistnost,
                            DoktorId = ordinace.DoktorID,
                            ImageSrc = ordinace.ImageSrc
                        },
                        OrdinaceImageSrc = ordinace.ImageSrc
                    }).FirstOrDefault();
        }

        public void UpdateProhlidka(ProhlidkyViewModel viewModel)
        {
            var sluzba = _context.LekarskeSluzby.FirstOrDefault(lz => lz.Id == viewModel.LekarskeSluzby.LekarskeSluzbyId);
            if (sluzba != null)
            {
                sluzba.Ukon = viewModel.LekarskeSluzby.Ukon;
                sluzba.Vysetreni = viewModel.LekarskeSluzby.Vysetreni;
                sluzba.Ockovani = viewModel.LekarskeSluzby.Ockovani;
                sluzba.Datum = viewModel.LekarskeSluzby.Datum;
                sluzba.KartaID = viewModel.Karta.KartaId;
                sluzba.OrdinaceID = viewModel.Ordinace.OrdinaceId;

                _context.LekarskeSluzby.Update(sluzba);
                _context.SaveChanges();
            }
        }
    }
}