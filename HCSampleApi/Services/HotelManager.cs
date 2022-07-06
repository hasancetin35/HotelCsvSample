using DataAccess.Repository;
using Entity;

namespace HCSampleApi.Services
{
    public class HotelManager :IHotelService
    {

        private readonly IGenericRepository<Hotel> _repository;


        public HotelManager(IGenericRepository<Hotel> repository)
        {
            _repository = repository;
        }


        public Hotel Create(Hotel hotel)
        {
            return _repository.Add(hotel);
        }



        public Hotel Delete(int id)
        {
            var deleteHotel = _repository.GetById(id);
            return _repository.Delete(deleteHotel);
        }

        public Hotel GetHotel(int id)
        {
            return _repository.GetById(id);
        }

        public List<Hotel> GetHotelAll()
        {
            return _repository.GetAll();
        }

        public Hotel UpdateHotel(int id, Hotel hotel)
        {


            return _repository.Update(id, hotel);
        }



    }
}
