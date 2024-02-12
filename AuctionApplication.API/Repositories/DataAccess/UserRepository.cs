using AuctionApplication.Contracts;
using AuctionApplication.Entities;

namespace AuctionApplication.Repositories.DataAccess;

public class UserRepository(AuctionApplicationDbContext dbContext) : IUserRepository
{
    public bool ExistUserWithEmail(string email)
    {
        return dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return dbContext.Users.First(user => user.Email.Equals((email)));
    }
}