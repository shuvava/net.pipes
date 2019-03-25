using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Stream.Service.Services
{
    public class PdfService: IPdfService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PdfService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SavePdfAsync()
        {
            const string url = "https://www.ecma-international.org/publications/files/ECMA-ST/Ecma-262.pdf";
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                using (System.IO.Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    string fileToWriteTo = Path.GetTempFileName();
                    using (System.IO.Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
            }
        }
    }
}
