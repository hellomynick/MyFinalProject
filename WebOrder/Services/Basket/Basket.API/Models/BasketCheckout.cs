using System;

namespace Basket.API.Models
{
    public class BasketCheckout
    {
        public string Buyer { get; set; }

        public Guid RequestId { get; set; }
    }
}
