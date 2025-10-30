using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class GebruikerService : IGebruikerService
{
    private readonly AppDbContext _db;
    public GebruikerService(AppDbContext db) => _db = db;

    public Task<List<Gebruiker>> GetAllAsync()
        => _db.Gebruikers.AsNoTracking().ToListAsync();

    public Task<Gebruiker?> GetByIdAsync(int id)
        => _db.Gebruikers.FindAsync(id).AsTask();

    public async Task<Gebruiker> CreateAsync(Gebruiker g)
    {
        _db.Gebruikers.Add(g);
        await _db.SaveChangesAsync();
        return g;
    }

    public async Task<bool> UpdateAsync(int id, Gebruiker g)
    {
        if (id != g.GebruikerId) return false;
        _db.Entry(g).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.Gebruikers.FindAsync(id);
        if (x is null) return false;
        _db.Gebruikers.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
