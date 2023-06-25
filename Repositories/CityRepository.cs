using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_AP2_POO.Interfaces;
using API_AP2_POO.Models;

namespace API_AP2_POO.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly List<City> _cities;

        public CityRepository()
        {
            _cities = new List<City>();
        }

        public Task<List<City>> GetCitiesAsync()
        {
            return Task.FromResult(_cities);
        }

        public Task<City> GetCityByIdAsync(int id)
        {
            var city = _cities.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(city);
        }

        public Task<City> CreateCityAsync(City city)
        {
            city.Id = _cities.Count + 1;
            _cities.Add(city);
            return Task.FromResult(city);
        }

        public Task<City> UpdateCityAsync(int id, City city)
        {
            var existingCity = _cities.FirstOrDefault(c => c.Id == id);
            if (existingCity != null)
            {
                existingCity.Name = city.Name;
                existingCity.Population = city.Population;
            }
            return Task.FromResult(existingCity);
        }

        public Task<bool> DeleteCityAsync(int id)
        {
            var city = _cities.FirstOrDefault(c => c.Id == id);
            if (city != null)
            {
                _cities.Remove(city);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
