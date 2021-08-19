using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class LoginService : BaseService<UserEntity>, ILoginService
    {
        private IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserEntity> FindByEmail(UserEntity entity)
        {
            if (entity != null && !string.IsNullOrWhiteSpace(entity.Email))
            {
                return await _userRepository.FindByEmailAsync(entity.Email);
            }
            return null;
        }
    }
}
