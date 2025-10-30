using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IGebruikerService
{
    Task<List<Gebruiker>> GetAllAsync();
    Task<Gebruiker?> GetByIdAsync(int id);
    Task<Gebruiker> CreateAsync(Gebruiker g);
    Task<bool> UpdateAsync(int id, Gebruiker g);
    Task<bool> DeleteAsync(int id);
}
