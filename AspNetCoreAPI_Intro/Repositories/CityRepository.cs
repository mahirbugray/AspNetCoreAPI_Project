using AspNetCoreAPI_Intro.Data;
using AspNetCoreAPI_Intro.Entities;
using AspNetCoreAPI_Intro.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreAPI_Intro.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CityDbContext _context;
        public CityRepository(CityDbContext context)
        {
            _context = context;
        }
        public async Task<City> CreateAsync(City city)
        {
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;    //id değeriyle birlikte dönüyor.
        }
        public async Task DeleteAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync(); 
        }
        public async Task<City> GetByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return city;
        }
        public async Task UpdateAsync(City city)
        {
            var orjCity = await _context.Cities.FirstOrDefaultAsync(c => c.Id == city.Id);
            _context.Entry(orjCity).CurrentValues.SetValues(city);
            await _context.SaveChangesAsync();
        }
    }
}
