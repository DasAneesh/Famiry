﻿using FamiryEntityLibrary;
using Microsoft.EntityFrameworkCore;

namespace FamiryEntityLibrary.Service
{
    public interface IDataEntityService<T> where T : IdentifiableEntity
    {
        Task<IEnumerable<T>> Get(DbSet<T> dbSet, List<int> ids);
        Task<bool> Set(DbSet<T> dbSet, List<T> entities);
        Task<bool> Remove(DbSet<T> dbSet, List<int> ids);
    }
}
