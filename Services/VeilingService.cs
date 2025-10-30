using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class VeilingService : IVeilingService
{
    private readonly AppDbContext _db;
    public VeilingService(AppDbContext db) => _db = db;

    public Task<List<Veiling>> GetAllAsync()
        => _db.Veilingen.AsNoTracking().ToListAsync();

    public Task<Veiling?> GetByIdAsync(int id)
        => _db.Veilingen.FindAsync(id).AsTask();

    public async Task<Veiling> CreateAsync(Veiling v)
    {
        _db.Veilingen.Add(v);
        await _db.SaveChangesAsync();
        return v;
    }

    public async Task<bool> UpdateAsync(int id, Veiling v)
    {
        if (id != v.VeilingId) return false;
        _db.Entry(v).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Veilingen.FindAsync(id);
        if (x is null) return false;
        _db.Veilingen.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
