using AspNetCoreAPI_Intro.Entities;

namespace AspNetCoreAPI_Intro.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task<City> CreateAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(City city);
    }
}
