using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Application.Repositories
{
    public interface IFileRepository
    {
        Task<File> AddAsync(File file, CancellationToken cancellationToken);

        Task AddAsync(List<File> files, CancellationToken cancellationToken);

        Task<File> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<List<File>> GetByAdvertisementIdAsync(Guid advertisementId, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
