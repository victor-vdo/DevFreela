﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetyByEmailAndPasswordAsync(string email, string password);
    }
}
