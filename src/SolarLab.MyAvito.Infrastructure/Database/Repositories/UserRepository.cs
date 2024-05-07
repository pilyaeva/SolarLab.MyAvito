using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolarLab.MyAvito.Application.Repositories;
using SolarLab.MyAvito.Domain;
using SolarLab.MyAvito.Infrastructure.DataBase;

namespace SolarLab.MyAvito.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

        public Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
