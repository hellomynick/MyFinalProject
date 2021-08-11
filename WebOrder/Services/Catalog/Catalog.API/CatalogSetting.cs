using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOrder.Services.Catalog.API
{
    public class CatalogSettings
    {
        public string PicBaseUrl { get; set; }

        public string EventBusConnection { get; set; }

        public bool UseCustomizationData { get; set; }

    }
}
