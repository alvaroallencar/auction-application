using AuctionApplication.Contracts;
using AuctionApplication.Entities;

namespace AuctionApplication.Repositories.DataAccess;

public class OfferRepository(AuctionApplicationDbContext dbContext) : IOfferRepository
{
    public void Add(Offer offer)
    {
        dbContext.Offers.Add(offer);

        dbContext.SaveChanges();
    }
}