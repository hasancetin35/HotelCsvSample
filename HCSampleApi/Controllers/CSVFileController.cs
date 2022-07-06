
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CsvHelper;
using System.Globalization;
using HCSampleApi.ValidationRules;

using DataAccess.DBContext;
using DataAccess.Operations;
using DataAccess.Model;
using HCSampleApi.Model;

namespace HCSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVFileController : ControllerBase




    {

      

        [HttpGet]

        public IActionResult Index(List<HotelModel> hotelm= null)

        {
            hotelm = hotelm == null ? new List<HotelModel>() : hotelm;

            return Ok() ;


        }



        [HttpPost("upload")]
        public IActionResult Upload([FromForm]IFormFile formFile, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment )
        {
              string newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{newName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {

                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }

            var hotelm = this.GetHotelList(newName);
            


            return Index();
            
        }

        [HttpGet("getlisthoteldb")]
        public IActionResult GetListHotelDB()
       {
            CSVDBOperations csvdb = new CSVDBOperations();

                return Ok( csvdb.ReadList());

        }





        [HttpGet("getlisthotel")]
        public IActionResult GetListHotel()
        {
            List<HotelModel> hotels = new List<HotelModel>();
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}" + "\\" + "NewFile.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    var hotel = csv.GetRecord<HotelModelCSV>();

                    HotelModel htl = new HotelModel { Name = hotel.Name, Adress = hotel.Adress, Contact = hotel.Contact, Phone = hotel.Phone, Stars = hotel.Stars, Uri = hotel.Uri };

                    hotels.Add(htl);


                }

            }



            return Ok(hotels);
        }





        private async  Task< List<HotelModel>> GetHotelList(string fileName)

        {

            var validator = new CSVValidator();

            List<HotelModel> hotels = new List<HotelModel>();

   // Read CSV
           CSVDBOperations csvdb = new CSVDBOperations();
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;

            using(var reader = new StreamReader(path))
            using (var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
            { 
                
                
                

                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    var hotel = csv.GetRecord<HotelModelCSV>();


                    HotelModel htl = new HotelModel { Name = hotel.Name, Adress = hotel.Adress, Contact = hotel.Contact, Phone = hotel.Phone, Stars = hotel.Stars, Uri = hotel.Uri };
                   
                    var validationResult=   validator.Validate(htl);

                 

                    if(validationResult.IsValid)
                    {
                            hotels.Add(htl);
                       

                    }


                    


                }
            }
            //Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {



                csv.WriteRecords(hotels);
            }



            csvdb.CreateList(hotels);
            
            return hotels;


        }


    }
}
