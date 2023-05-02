﻿using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Add(T model);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(int id);
        bool Any();
        int Count();
        
        /// <summary>
        /// DANGEROUS. Try to not use it
        /// </summary>
        void Update(T model);
    }
}