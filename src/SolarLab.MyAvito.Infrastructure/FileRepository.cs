using SolarLab.MyAvito.Application;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Infrastructure
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
    }
}
