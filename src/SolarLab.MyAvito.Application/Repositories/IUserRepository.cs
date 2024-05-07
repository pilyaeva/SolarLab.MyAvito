using SolarLab.MyAvito.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken);
        Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken);
    }
}
