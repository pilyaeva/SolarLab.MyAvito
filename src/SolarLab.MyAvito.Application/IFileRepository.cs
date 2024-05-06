using SolarLab.MyAvito.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Application
{
    public interface IFileRepository
    {
        Task<File> AddAsync(File file, CancellationToken cancellationToken);

        Task AddAsync(List<File> files, CancellationToken cancellationToken);
    }
}
