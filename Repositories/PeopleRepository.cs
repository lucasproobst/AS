using System.Collections.Generic;
using System.Threading.Tasks;
using API_AP2_POO.Data;
using API_AP2_POO.Interfaces;
using API_AP2_POO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AP2_POO.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;

        public PeopleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<People>> GetPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<People> GetPeopleByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<People> CreatePeopleAsync(People people)
        {
            _context.People.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }

        public async Task<People> UpdatePeopleAsync(int id, People people)
        {
            var existingPeople = await _context.People.FindAsync(id);
            if (existingPeople == null)
                return null;

            existingPeople.Name = people.Name;
            existingPeople.LastName = people.LastName;
            existingPeople.Age = people.Age;
            existingPeople.CityId = people.CityId;

            await _context.SaveChangesAsync();
            return existingPeople;
        }

        public async Task<bool> DeletePeopleAsync(int id)
        {
            var existingPeople = await _context.People.FindAsync(id);
            if (existingPeople == null)
                return false;

            _context.People.Remove(existingPeople);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
