using System.ComponentModel.DataAnnotations;

namespace CRUDAPI.Model
{
    public class UpdateStudentDto
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Fees is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Fees must be a positive number.")]
        public decimal? Fees { get; set; }
    }
}
