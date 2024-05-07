using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Application.Repositories;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Infrastructure.Database.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<File> AddAsync(File file, CancellationToken cancellationToken)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync(cancellationToken);

            return file;
        }

        public async Task AddAsync(List<File> files, CancellationToken cancellationToken)
        {
            _context.Files.AddRange(files);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<File> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context
                .Files
                .AsNoTracking()
                .FirstOrDefaultAsync(file => file.Id == id, cancellationToken);
        }

        public async Task<List<File>> GetByAdvertisementIdAsync(Guid advertisementId, CancellationToken cancellationToken)
        {
            return await _context
                .Files
                .AsNoTracking()
                .Where(file => file.AdvertisementId == advertisementId)
                .ToListAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _context.Files.FirstOrDefaultAsync(file => file.Id == id, cancellationToken);

            _context.Files.Remove(file);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
