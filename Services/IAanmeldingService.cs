using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IAanmeldingService
{
    Task<List<Aanmelding>> GetAllAsync();
    Task<Aanmelding?> GetByIdAsync(int id);
    Task<Aanmelding> CreateAsync(Aanmelding a);
    Task<bool> UpdateAsync(int id, Aanmelding a);
    Task<bool> DeleteAsync(int id);
}
