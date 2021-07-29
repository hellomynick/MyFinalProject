using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityStore.API.Models
{
    public class ApplicationStore : IdentityUser
    {
        [Required]
        public string Palace { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [RegularExpression(@"^(1[0-2]|0[1-9]):[0-5][0-9]\040(AM|am|PM|pm){2}", ErrorMessage = "Expiration should match a valid H/M value")]
        public string Open { get; set; }
        [Required]
        [RegularExpression(@"^(1[0-2]|0[1-9]):[0-5][0-9]\040(AM|am|PM|pm){2}", ErrorMessage = "Expiration should match a valid H/M value")]
        public string Close { get; set; }
    }
}
