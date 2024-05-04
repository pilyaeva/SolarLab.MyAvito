using SolarLab.MyAvito.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Application
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken);
        Task<User> GetAllAsync(CancellationToken cancellationToken);
        Task<User> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<User> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<User> EditAsync(User user, CancellationToken cancellationToken);
    }
}
