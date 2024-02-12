using AuctionApplication.Contracts;
using AuctionApplication.Entities;

namespace AuctionApplication.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase(IAuctionRepository repository)
{
    public Auction? Execute()
    {
        return repository.GetCurrent();
    }
}