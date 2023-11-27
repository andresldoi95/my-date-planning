using AutoMapper;
using MyDatePlanningApi.Models.Users;
using MyDatePlanningData.Entities;
using MyDatePlanningRepositories.Interfaces;
using MyDatePlanningServices.Interfaces;

namespace MyDatePlanningServices.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(CreateUser user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _userRepository.AddUserAsync(userEntity);
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
