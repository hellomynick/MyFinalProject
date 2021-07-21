using WebOrder.BuildingBlocks.EventBus.Events;
using WebOrder.Services.Basket.API.Models;
using System;

namespace Basket.API.IntegrationEvents.Events
{
    public record UserCheckoutAcceptedIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; }

        public string UserName { get; }

        public int OrderNumber { get; init; }

        public string Buyer { get; init; }

        public Guid RequestId { get; init; }

        public CustomerBasket Basket { get; }

        public UserCheckoutAcceptedIntegrationEvent(string userId, string userName, string buyer, Guid requestId,
            CustomerBasket basket)
        {
            UserId = userId;
            UserName = userName;
            Buyer = buyer;
            Basket = basket;
            RequestId = requestId;
        }

    }
}