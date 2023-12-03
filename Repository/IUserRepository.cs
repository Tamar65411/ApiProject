using DTO;
using Entities;


namespace Repository
{
    public interface IUserRepository
    {
        Task<UsersTbl> addUser(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(UserLoginDTO userLoginDTO);
        //Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task updateUser( UsersTbl value);
        //Task<User> getUserById(int id);
    }
}