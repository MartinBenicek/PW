using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Nemocnice.application.ViewModels
{
    public class OrdinaceViewModel
    {
        public int OrdinaceId { get; set; }
        public string? Budova { get; set; }
        public string? Mistnost { get; set; }
        public string? ImageSrc { get; set; }
        public IFormFile? Image { get; set; }
        public int DoktorId { get; set; }
    }
}
