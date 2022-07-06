using CsvHelper.Configuration.Attributes;

namespace HCSampleApi.Model
{

    //name,address,stars,contact,phone,uri
    public class HotelModelCSV
    {
        [Index(0)]
        public string Name { get; set; } = "";
        [Index(1)]
        public string Adress { get; set; } = "";
        [Index(2)]
        public int Stars { get; set; } 
        [Index(3)]
        public string Contact { get; set; } = "";
        [Index(4)]
        public string Phone { get; set; } = "";
        [Index(5)]
        public string Uri { get; set; } = "";


    }
}
