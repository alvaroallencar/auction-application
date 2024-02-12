using AuctionApplication.Entities;

namespace AuctionApplication.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}