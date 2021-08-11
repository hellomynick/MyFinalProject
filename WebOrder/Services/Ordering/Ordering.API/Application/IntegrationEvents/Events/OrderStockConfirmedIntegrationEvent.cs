namespace Ordering.API.Application.IntegrationEvents.Events
{
    using WebOrder.BuildingBlocks.EventBus.Events;

    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStockConfirmedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}