using SolarLab.MyAvito.Domain;
using System.Threading.Tasks;
using System.Threading;
using SolarLab.MyAvito.Application.Repositories.Models;
using System;

namespace SolarLab.MyAvito.Application.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);

        Task<Advertisement> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<PagedAdvertisementsByUserDtoOut> GetPagedByUserIdAsync(Guid userId, int pageSize, int pageIndex, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
