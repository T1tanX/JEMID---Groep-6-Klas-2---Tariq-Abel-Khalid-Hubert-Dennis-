using VeilingApi.Models;

namespace VeilingApi.Services;

public interface IVeilingProductService
{
    Task<List<VeilingProduct>> GetAllAsync();
    Task<VeilingProduct?> GetByIdAsync(int id);
    Task<VeilingProduct> CreateAsync(VeilingProduct vp);   // kan FK/unique fouten geven
    Task<bool> UpdateAsync(int id, VeilingProduct vp);     // idem
    Task<bool> DeleteAsync(int id);
}
