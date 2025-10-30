using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class BiedingService : IBiedingService
{
    private readonly AppDbContext _db;
    public BiedingService(AppDbContext db) => _db = db;

    public Task<List<Bieding>> GetAllAsync()
        => _db.Biedingen.AsNoTracking().ToListAsync();

    public Task<Bieding?> GetByIdAsync(int id)
        => _db.Biedingen.FindAsync(id).AsTask();

    public async Task<Bieding> CreateAsync(Bieding b)
    {
        _db.Biedingen.Add(b);
        await _db.SaveChangesAsync();
        return b;
    }

    public async Task<bool> UpdateAsync(int id, Bieding b)
    {
        if (id != b.BiedingId) return false;
        _db.Entry(b).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Biedingen.FindAsync(id);
        if (x is null) return false;
        _db.Biedingen.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
