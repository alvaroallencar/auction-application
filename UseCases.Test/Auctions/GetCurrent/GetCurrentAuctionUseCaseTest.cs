using AuctionApplication.Communication.Requests;
using AuctionApplication.Contracts;
using AuctionApplication.Entities;
using AuctionApplication.Services;
using AuctionApplication.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace TestProject1.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Arrange
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 500)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //Act
        var act = () => useCase.Execute(itemId, request);

        //Assert
        act.Should().NotThrow();
    }
}