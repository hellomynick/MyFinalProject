namespace Ordering.API.Application.IntegrationEvents.Events
{
    using WebOrder.BuildingBlocks.EventBus.Events;

    public record OrderStatusChangedToStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }

        public OrderStatusChangedToStockConfirmedIntegrationEvent(int orderId, string orderStatus, string buyerName)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
        }
    }
}