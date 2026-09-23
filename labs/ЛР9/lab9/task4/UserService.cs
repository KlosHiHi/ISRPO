using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);
    public UserService(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<User>> GetActiveUsersAsync()
    {
        List<User> users = null!;
        await GetCachedActiveUsersAsync(users);

        var  = await _context.Users
                .AsNoTracking()
                .Where(u => u.IsActive)
                .ToListAsync();

        return users;
    }

    public async Task<List<User>> GetUsersWithOrdersAsync()
        => await _context.Users
            .Include(u => u.Orders)
            .Select(u => new User() { Name = u.Name, Orders = u.Orders })
            .ToListAsync();

    public async Task AddUsersAsync(List<User> users)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[{DateTime.Now}] {ex.Message}");
            await transaction.RollbackAsync();
        }
    }
    
    private async Task<List<User>> GetCachedActiveUsersAsync(List<User> users)
    {
        if (!_cache.TryGetValue("Active Users", out users))
        {
            foreach (var user in _context.Users)
            {
                _cache.Set("Active Users", user, _cacheDuration);
            }
        }

        return users;
    }
}