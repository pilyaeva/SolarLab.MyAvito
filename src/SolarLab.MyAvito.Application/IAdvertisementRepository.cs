using SolarLab.MyAvito.Domain;
using System.Threading.Tasks;
using System.Threading;

namespace SolarLab.MyAvito.Application
{
    public interface IAdvertisementRepository
    {
        Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    }
}
