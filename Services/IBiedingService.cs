using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IBiedingService
{
    Task<List<Bieding>> GetAllAsync();
    Task<Bieding?> GetByIdAsync(int id);
    Task<Bieding> CreateAsync(Bieding b);
    Task<bool> UpdateAsync(int id, Bieding b);
    Task<bool> DeleteAsync(int id);
}
