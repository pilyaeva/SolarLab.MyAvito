using SolarLab.MyAvito.Application;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Infrastructure
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;
        public AdvertisementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken)
        {
            _context.Advertisements.Add(advertisement);
            await _context.SaveChangesAsync();

            return advertisement;
        }
    }
}
