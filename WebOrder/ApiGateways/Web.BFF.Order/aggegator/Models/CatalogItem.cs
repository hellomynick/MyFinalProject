using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aggegator.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string PictureUri { get; set; }
    }
}
