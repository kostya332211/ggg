using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LABA3.Models
{
    public class PersonValidationModel
    {
        [DisplayName("Person Name")]
        [Required]
        public string PersonName { get; set; }
        [DisplayName("Person Number")]
        [Required]
        public string PhoneNumber { get; set; }

    }
}