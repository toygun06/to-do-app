﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<User> UpdateAsync(User user);
        Task<User> GetAuthenticatedUserAsync();
        Task<User> GetUserByEmailAsync(string email);
    }
}
