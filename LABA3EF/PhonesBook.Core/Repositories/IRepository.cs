﻿using System;
using System.Collections.Generic;
using PhonesBook.Core.Entities;

namespace PhonesBook.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where  TEntity : Entity<TKey>
    {
        TEntity Get(Predicate<TEntity> predicate);
        IEnumerable<TEntity> All();
        void Insert(TEntity entity);
        void Delete(Predicate<TEntity> predicate);
    }
}
