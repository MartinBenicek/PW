using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
   
public class OrdinaceAppService : IOrdinaceService
    {
        private readonly NemocniceDbContext _context;
        private readonly IFileUploadService _fileUploadService;

        public OrdinaceAppService(NemocniceDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
        }

        public List<OrdinaceViewModel> GetOrdinace()
        {
            return _context.Ordinace.Select(o => new OrdinaceViewModel
            {
                OrdinaceId = o.Id,
                Budova = o.Budova,
                Mistnost = o.Mistnost,
                DoktorId = o.DoktorID,
                ImageSrc = o.ImageSrc
            }).ToList();
        }

        public OrdinaceViewModel GetOrdinaceById(int id)
        {
            return _context.Ordinace.Where(o => o.Id == id).Select(o => new OrdinaceViewModel
            {
                OrdinaceId = o.Id,
                Budova = o.Budova,
                Mistnost = o.Mistnost,
                DoktorId = o.DoktorID,
                ImageSrc = o.ImageSrc
            }).FirstOrDefault();
        }

        public void CreateOrdinace(OrdinaceViewModel viewModel)
        {
            var ordinace = new Ordinace
            {
                Budova = viewModel.Budova,
                Mistnost = viewModel.Mistnost,
                DoktorID = viewModel.DoktorId,
                ImageSrc = viewModel.ImageSrc
            };

            if (viewModel.Image != null)
            {
                string imageSrc = _fileUploadService.FileUpload(viewModel.Image, Path.Combine("img", "ordinace"));
                ordinace.ImageSrc = imageSrc;
            }

            _context.Ordinace.Add(ordinace);
            _context.SaveChanges();
        }

        public void UpdateOrdinace(OrdinaceViewModel viewModel)
        {
            var ordinace = _context.Ordinace.FirstOrDefault(o => o.Id == viewModel.OrdinaceId);
            if (ordinace != null)
            {
                ordinace.Budova = viewModel.Budova;
                ordinace.Mistnost = viewModel.Mistnost;
                ordinace.DoktorID = viewModel.DoktorId;

                if (viewModel.Image != null)
                {
                    string imageSrc = _fileUploadService.FileUpload(viewModel.Image, Path.Combine("img", "ordinace"));
                    ordinace.ImageSrc = imageSrc;
                }

                _context.Ordinace.Update(ordinace);
                _context.SaveChanges();
            }
        }

        public void DeleteOrdinace(int id)
        {
            var ordinace = _context.Ordinace.FirstOrDefault(o => o.Id == id);
            if (ordinace != null)
            {
                _context.Ordinace.Remove(ordinace);
                _context.SaveChanges();
            }
        }
    }
    
}
