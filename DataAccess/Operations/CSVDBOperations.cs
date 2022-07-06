using DataAccess.DBContext;
using DataAccess.Model;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Operations
{
    public class CSVDBOperations


    {





        public void Create(HotelModel hotel)
        {


            using (Context _context = new Context())
            {
                _context.Hotels.Add(new Entity.Hotel() { Name = hotel.Name, Adress = hotel.Adress, Contact = hotel.Contact, Phone = hotel.Phone, Stars = hotel.Stars, Uri = hotel.Uri });
                _context.SaveChanges();
            }





        }



        public List<HotelModel> ReadList()
        {
            using (Context _context = new Context())

            {



                var hotellist = _context.Hotels.OrderBy(x => x.HotelID).ToList<Hotel>();

                List<HotelModel> vm = new List<HotelModel>();

                foreach (var hotel in hotellist)
                {
                    vm.Add(new HotelModel()
                    {
                        Name= hotel.Name,
                        Contact=hotel.Contact,
                        Phone=hotel.Phone,
                        Adress=hotel.Adress,
                        Stars=hotel.Stars,
                        Uri=hotel.Uri
                        
                        
                    }
                        );
                }

                return vm;





            }





        }



      
        public void CreateList(List<HotelModel> hotels)
        {


            using (Context _context = new Context())
            {



                foreach (HotelModel hotel in hotels)
                {
                    _context.Hotels.Add(
                        
                        
                        
                        new Entity.Hotel() { Name = hotel.Name, Adress = hotel.Adress, Contact = hotel.Contact, Phone = hotel.Phone, Stars = hotel.Stars, Uri = hotel.Uri });
                }

                try
                {
               _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }

                
            }





        }

    }

    
}
