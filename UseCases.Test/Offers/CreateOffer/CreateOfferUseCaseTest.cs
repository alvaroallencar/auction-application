using AuctionApplication.Contracts;
using AuctionApplication.Entities;
using AuctionApplication.Enums;
using AuctionApplication.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace TestProject1.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 500))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) =>
            [
                new Item
                {
                    Id = f.Random.Number(1, 500),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            ]).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //Act
        var auction = useCase.Execute();

        //Assert
        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}