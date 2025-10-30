using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IToewijzingService
{
    Task<List<Toewijzing>> GetAllAsync();
    Task<Toewijzing?> GetByIdAsync(int id);
    Task<Toewijzing> CreateAsync(Toewijzing t);  // kan unique (1:1) errors geven
    Task<bool> UpdateAsync(int id, Toewijzing t);
    Task<bool> DeleteAsync(int id);
}
