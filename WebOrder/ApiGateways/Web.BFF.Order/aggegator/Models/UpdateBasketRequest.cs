using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aggegator.Models
{
    public class UpdateBasketRequest
    {
        public string BuyerId { get; set; }

        public IEnumerable<UpdateBasketRequestItemData> Items { get; set; }
    }
}
