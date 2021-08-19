using System.Collections.Generic;

namespace WebOrder.Web.Shopping.HttpAggregator.Models
{

    public class BasketData
    {
        public string BuyerId { get; set; }

        public List<BasketDataItem> Items { get; set; } = new List<BasketDataItem>();

        public BasketData()
        {
        }

        public BasketData(string buyerId)
        {
            BuyerId = buyerId;
        }
    }

}