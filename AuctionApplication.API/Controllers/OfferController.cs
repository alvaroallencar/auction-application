using AuctionApplication.Communication.Requests;
using AuctionApplication.Filters;
using AuctionApplication.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AuctionApplicationBaseController
{
    [HttpPost]
    [Route("{itemId:int}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}