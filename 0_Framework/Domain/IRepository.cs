﻿namespace Framework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        Task<T> GetById(TKey id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T command);
        Task Update(T command);
        Task Delete(TKey id);

    }
}
