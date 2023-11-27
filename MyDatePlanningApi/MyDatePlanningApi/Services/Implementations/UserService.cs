using AutoMapper;
using MyDatePlanningApi.Models.Users;
using MyDatePlanningData.Entities;
using MyDatePlanningRepositories.Interfaces;
using MyDatePlanningApi.Services.Interfaces;

namespace MyDatePlanningApi.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IStringHasher _stringHasher;
        public UserService(IUserRepository userRepository, IMapper mapper, IStringHasher stringHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _stringHasher = stringHasher;
        }

        public async Task<CreatedUser> AddUserAsync(CreateUser user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.Password = _stringHasher.Hash(user.Password);
            return _mapper.Map<CreatedUser>(await _userRepository.AddUserAsync(userEntity));
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _userRepository.GetUserAsync(email);
        }

        public async Task UpdateUserAsync(UpdateUser user)
        {
            var userEntity = _mapper.Map<User>(user);
            await _userRepository.UpdateUserAsync(userEntity);
        }
    }
}
