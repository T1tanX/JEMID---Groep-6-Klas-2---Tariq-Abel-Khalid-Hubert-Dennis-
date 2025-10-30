using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class AanvoerderService : IAanvoerderService
{
    private readonly AppDbContext _db;
    public AanvoerderService(AppDbContext db) => _db = db;

    public Task<List<Aanvoerder>> GetAllAsync()
        => _db.Aanvoerders.AsNoTracking().ToListAsync();

    public Task<Aanvoerder?> GetByIdAsync(int id)
        => _db.Aanvoerders.FindAsync(id).AsTask();

    public async Task<Aanvoerder> CreateAsync(Aanvoerder a)
    {
        _db.Aanvoerders.Add(a);
        await _db.SaveChangesAsync();
        return a;
    }

    public async Task<bool> UpdateAsync(int id, Aanvoerder a)
    {
        if (id != a.AanvoerderId) return false;
        _db.Entry(a).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Aanvoerders.FindAsync(id);
        if (x is null) return false;
        _db.Aanvoerders.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
