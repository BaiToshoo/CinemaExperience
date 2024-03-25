using CinemaExperience.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaExperience.Infrastructure.Data.Common;
public class Repository : IRepository
{
    private readonly DbContext context;

    public Repository(CinemaExperienceDbContext _cintext)
    {
        context = _cintext;
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return context.Set<T>();
    }
    public IQueryable<T> All<T>() where T : class
    {
        return DbSet<T>();
    }
    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return DbSet<T>().AsNoTracking();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public async Task DeleteAsync<T>(T entity) where T : class
    {
        DbSet<T>().Remove(entity);
    }

    public async Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class
    {
        DbSet<T>().RemoveRange(entities);
    }

    public async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await DbSet<T>().FindAsync(id);
    }
}
