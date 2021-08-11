namespace Ordering.API.Application.IntegrationEvents.Events
{
    using WebOrder.BuildingBlocks.EventBus.Events;

    public record OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}