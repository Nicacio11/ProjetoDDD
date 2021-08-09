using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _userRepository.ExistsAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> Get()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<UserEntity> Post(UserEntity entity)
        {
            return await _userRepository.InsertAsync(entity);
        }

        public async Task<UserEntity> Put(UserEntity entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
