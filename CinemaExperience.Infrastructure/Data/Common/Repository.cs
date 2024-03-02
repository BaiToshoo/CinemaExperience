﻿using CinemaExperience.infrastructure.Data;
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
}
