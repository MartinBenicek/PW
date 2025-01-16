using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class OrdinaceController : Controller
    {
        private readonly IOrdinaceService _ordinaceService;
        private readonly IFileUploadService _fileUploadService;

        public OrdinaceController(IOrdinaceService ordinaceService, IFileUploadService fileUploadService)
        {
            _ordinaceService = ordinaceService;
            _fileUploadService = fileUploadService;
        }

        public IActionResult Select()
        {
            var ordinace = _ordinaceService.GetOrdinace();
            return View(ordinace);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new OrdinaceViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrdinaceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Image != null)
                {
                    string imageSrc = _fileUploadService.FileUpload(viewModel.Image, Path.Combine("img", "ordinace"));
                    viewModel.ImageSrc = imageSrc;
                }
                _ordinaceService.CreateOrdinace(viewModel);
                return RedirectToAction(nameof(Select));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ordinace = _ordinaceService.GetOrdinaceById(id);
            if (ordinace == null)
            {
                return NotFound();
            }
            return View(ordinace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrdinaceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Image != null)
                {
                    string imageSrc = _fileUploadService.FileUpload(viewModel.Image, Path.Combine("img", "ordinace"));
                    viewModel.ImageSrc = imageSrc;
                }
                _ordinaceService.UpdateOrdinace(viewModel);
                return RedirectToAction(nameof(Select));
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _ordinaceService.DeleteOrdinace(id);
            return RedirectToAction(nameof(Select));
        }
    }
}
