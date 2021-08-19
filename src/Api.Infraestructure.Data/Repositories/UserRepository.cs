using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestructure.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {
        }
        public async Task<UserEntity> FindByEmailAsync(string email)
        {
            return await _dataSet.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
