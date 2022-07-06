using Entity;

namespace HCSampleApi.Services
{
    public interface IHotelService
    {

        Hotel Create(Hotel hotel);

        Hotel GetHotel(int id);

        List<Hotel> GetHotelAll();

        Hotel Delete(int id);

        Hotel UpdateHotel(int id, Hotel hotel);
    }
}
