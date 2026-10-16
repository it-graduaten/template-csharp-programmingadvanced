using WebApi.Models;

namespace WebApi.Repositories;

public interface ILaptopRepository : IGenericRepository<Laptop>
{
    Task<IEnumerable<Laptop>> GetLaptopsByMerkAsync(string merk);
    Task<IEnumerable<Laptop>> GetLaptopsByRamInGBAsync(int ramInGB);
    Task<IEnumerable<Laptop>> GetLaptopsSortedByPrijsAsync(bool descending);
    Task<int> CountLaptopsByMerkAsync(string merk);
}
