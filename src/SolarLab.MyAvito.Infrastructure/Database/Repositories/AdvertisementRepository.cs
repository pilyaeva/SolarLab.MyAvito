using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Application.Repositories;
using SolarLab.MyAvito.Application.Repositories.Models;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Infrastructure.Database.Repositories
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

        public async Task<Advertisement> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Advertisements.FirstOrDefaultAsync(advertisement => advertisement.Id == id, cancellationToken);
        }

        public async Task<PagedAdvertisementsByUserDtoOut> GetPagedByUserIdAsync(Guid userId, int pageSize, int pageIndex, CancellationToken cancellationToken)
        {
            var query = _context
                .Advertisements
                .AsNoTracking()
                .Where(advertisement => advertisement.UserId == userId)
                .OrderByDescending(advertisement => advertisement.CreatedAt);

            var count = await query.CountAsync(cancellationToken);

            var results = await query
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedAdvertisementsByUserDtoOut
            {
                Advertisements = results,
                MaxPage = (count % pageSize == 0) ? count / pageSize : count / pageSize + 1
            };
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var advertisement = await _context.Advertisements.FirstOrDefaultAsync(advertisement => advertisement.Id == id, cancellationToken);

            _context.Advertisements.Remove(advertisement);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
