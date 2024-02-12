using AuctionApplication.Entities;

namespace AuctionApplication.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}