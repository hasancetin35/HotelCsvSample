using HotelCsvSample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HotelCsvSample.Controllers
{
    public class HomeController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
          

            
            return View();
        }

       

       

        public async Task<IActionResult> List()

        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5272/api/CSVFile/getlisthotel");

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK )
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<ResponseModel>>(jsonData);

                return View(result);



            }
            else
            {
return View(null);
            }
            

        }




        public async Task<IActionResult> ListDb()

        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5272/api/CSVFile/getlisthoteldb");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<ResponseModel>>(jsonData);

                return View(result);



            }
            else
            {
                return View(null);
            }


        }




        public IActionResult Upload()
        {



            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Upload(IFormFile file)
        {

            var client = _httpClientFactory.CreateClient();
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var bytes = stream.ToArray();

            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(content,"formFile",file.FileName);

            await client.PostAsync("http://localhost:5272/api/CSVFile/upload",formData);
            return View();
        }
    }
}