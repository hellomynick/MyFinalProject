using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aggegator.Models
{
    public class OrderData
    {
        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public decimal Total { get; set; }

        public string Description { get; set; }
        public bool TypeOrder { get; set; }

        public bool IsDraft { get; set; }

        public string Buyer { get; set; }

        public List<OrderItemData> OrderItems { get; } = new List<OrderItemData>();
    }
}
