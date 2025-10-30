using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IVeilingService
{
    Task<List<Veiling>> GetAllAsync();
    Task<Veiling?> GetByIdAsync(int id);
    Task<Veiling> CreateAsync(Veiling v);
    Task<bool> UpdateAsync(int id, Veiling v);
    Task<bool> DeleteAsync(int id);
}
