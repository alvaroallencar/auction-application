using AuctionApplication.Contracts;
using AuctionApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Repositories.DataAccess;

public class AuctionRepository(AuctionApplicationDbContext dbContext) : IAuctionRepository
{
    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}