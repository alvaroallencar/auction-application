using AuctionApplication.Communication.Requests;
using AuctionApplication.Contracts;
using AuctionApplication.Entities;
using AuctionApplication.Repositories;
using AuctionApplication.Services;

namespace AuctionApplication.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
{
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Add(offer);

        return offer.Id;
    }
}