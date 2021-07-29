using System.ComponentModel.DataAnnotations;

namespace IdentityStore.API.Models.ManagerViewModel
{
    public record AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; init; }
    }
}
