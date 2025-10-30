using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IAanvoerderService
{
    Task<List<Aanvoerder>> GetAllAsync();
    Task<Aanvoerder?> GetByIdAsync(int id);
    Task<Aanvoerder> CreateAsync(Aanvoerder a);
    Task<bool> UpdateAsync(int id, Aanvoerder a);
    Task<bool> DeleteAsync(int id);
}