﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using Microsoft.EntityFrameworkCore;
namespace DataGovernanceTool.BusinessLogic.Managers
{

    public abstract class RepositoryManager<TEntity> : IRepositoryManager<TEntity>//where TEntity : Base
    {
        protected readonly IRepository<TEntity> Repository;

        protected RepositoryManager(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<String> GetType(int id) {
            return (await Repository.GetAsync(id)).GetType().Name;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await Repository.FindAsync(keys);
        }

        public virtual async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Filter(predicate).ToListAsync();
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await Repository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> ReplaceAsync(int id, TEntity entity)
        {
            return await Repository.ReplaceAsync(id, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }
    }
}
