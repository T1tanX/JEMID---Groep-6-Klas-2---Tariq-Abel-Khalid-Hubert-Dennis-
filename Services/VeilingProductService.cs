using Microsoft.EntityFrameworkCore;
using VeilingApi.Data;
using VeilingApi.Models;

namespace VeilingApi.Services;

public class VeilingProductService : IVeilingProductService
{
    private readonly AppDbContext _db;
    public VeilingProductService(AppDbContext db) => _db = db;

    public Task<List<VeilingProduct>> GetAllAsync()
        => _db.VeilingProducts.AsNoTracking().ToListAsync();

    public Task<VeilingProduct?> GetByIdAsync(int id)
        => _db.VeilingProducts.FindAsync(id).AsTask();

    public async Task<VeilingProduct> CreateAsync(VeilingProduct vp)
    {
        _db.VeilingProducts.Add(vp);
        await _db.SaveChangesAsync();   // FK/unique constraints worden hier gevalideerd
        return vp;
    }

    public async Task<bool> UpdateAsync(int id, VeilingProduct vp)
    {
        if (id != vp.VeilingProductId) return false;
        _db.Entry(vp).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var x = await _db.VeilingProducts.FindAsync(id);
        if (x is null) return false;
        _db.VeilingProducts.Remove(x);
        await _db.SaveChangesAsync();
        return true;
    }
}
