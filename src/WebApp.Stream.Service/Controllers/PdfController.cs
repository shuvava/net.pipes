using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Stream.Service.Services;

namespace WebApp.Stream.Service.Controllers
{
    [Route("/pdf")]
    public class PdfController: ControllerBase
    {
        private readonly IPdfService _service;
        public PdfController(IPdfService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task GetTest() => await _service.SavePdfAsync().ConfigureAwait(false);
    }
}
