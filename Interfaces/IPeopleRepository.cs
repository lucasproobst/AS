using System.Collections.Generic;
using System.Threading.Tasks;
using API_AP2_POO.Models;

namespace API_AP2_POO.Interfaces
{
    public interface IPeopleRepository
    {
        Task<List<People>> GetPeopleAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task<People> CreatePeopleAsync(People people);
        Task<People> UpdatePeopleAsync(int id, People people);
        Task<bool> DeletePeopleAsync(int id);
    }
}
