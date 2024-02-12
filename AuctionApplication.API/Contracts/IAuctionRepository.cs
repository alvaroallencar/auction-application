using AuctionApplication.Entities;

namespace AuctionApplication.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}