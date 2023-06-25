using System.Collections.Generic;
using System.Threading.Tasks;
using API_AP2_POO.Models;

namespace API_AP2_POO.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<City> CreateCityAsync(City city);
        Task<City> UpdateCityAsync(int id, City city);
        Task<bool> DeleteCityAsync(int id);
    }
}
