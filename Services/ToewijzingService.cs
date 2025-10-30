using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class ToewijzingService : IToewijzingService
{
    private readonly AppDbContext _db;
    public ToewijzingService(AppDbContext db) => _db = db;

    public Task<List<Toewijzing>> GetAllAsync()
        => _db.Toewijzingen.AsNoTracking().ToListAsync();

    public Task<Toewijzing?> GetByIdAsync(int id)
        => _db.Toewijzingen.FindAsync(id).AsTask();

    public async Task<Toewijzing> CreateAsync(Toewijzing t)
    {
        _db.Toewijzingen.Add(t);
        await _db.SaveChangesAsync();   // unique 1:1 met VeilingProduct wordt hier afgedwongen
        return t;
    }

    public async Task<bool> UpdateAsync(int id, Toewijzing t)
    {
        if (id != t.ToewijzingId) return false;
        _db.Entry(t).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Toewijzingen.FindAsync(id);
        if (x is null) return false;
        _db.Toewijzingen.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
