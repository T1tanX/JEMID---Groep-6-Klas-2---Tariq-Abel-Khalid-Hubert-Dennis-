using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class AanmeldingService : IAanmeldingService
{
    private readonly AppDbContext _db;
    public AanmeldingService(AppDbContext db) => _db = db;

    public Task<List<Aanmelding>> GetAllAsync()
        => _db.Aanmeldingen.AsNoTracking().ToListAsync();

    public Task<Aanmelding?> GetByIdAsync(int id)
        => _db.Aanmeldingen.FindAsync(id).AsTask();

    public async Task<Aanmelding> CreateAsync(Aanmelding a)
    {
        _db.Aanmeldingen.Add(a);
        await _db.SaveChangesAsync();
        return a;
    }

    public async Task<bool> UpdateAsync(int id, Aanmelding a)
    {
        if (id != a.AanmeldingId) return false;
        _db.Entry(a).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Aanmeldingen.FindAsync(id);
        if (x is null) return false;
        _db.Aanmeldingen.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
