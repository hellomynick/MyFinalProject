using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aggegator.Models
{
    public class UpdateBasketRequestItemData
    {
        public string Id { get; set; }          // Basket id

        public int ProductId { get; set; }      // Catalog item id

        public int Quantity { get; set; }       // Quantity
    }
}
