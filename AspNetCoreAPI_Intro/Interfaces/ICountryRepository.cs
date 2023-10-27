using AspNetCoreAPI_Intro.Entities;

namespace AspNetCoreAPI_Intro.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
    }
}
