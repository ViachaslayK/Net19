﻿using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Cart GetByName(string name);
        void RemoveByName(string name);

    }
}
