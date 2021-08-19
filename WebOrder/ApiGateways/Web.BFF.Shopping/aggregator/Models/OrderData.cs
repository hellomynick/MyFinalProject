using System;
using System.Collections.Generic;

namespace WebOrder.Web.Shopping.HttpAggregator.Models
{

    public class OrderData
    {
        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public decimal Total { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string Street { get; set; }


        public string Country { get; set; }


        public string Buyer { get; set; }

        public List<OrderItemData> OrderItems { get; } = new List<OrderItemData>();
    }

}