using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infraestructure.Data.Context;

namespace Api.Infraestructure.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {

        }
    }
}
