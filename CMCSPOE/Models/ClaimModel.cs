using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CMCSPOE.Models
{
    public class ClaimModel
    {
        public int Id { get; set; }

     
        public int LecturerId { get; set; }

        [Required(ErrorMessage = "Hours worked is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Hours worked must be a positive number.")]
        public decimal HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Hourly rate must be a positive number.")]
        public decimal HourlyRate { get; set; }

        public string? AdditionalNotes { get; set; }
        public string? Status { get; set; } // "Pending", "Approved", "Rejected"
        public string? SupportingDocument { get; set; }
        public string? Description { get; set; }

        public DateTime DateCreated { get;set; }

        public string? ClaimValue { get; set; }

        [NotMapped]
        public IFormFile supportingDocument {  get; set; }
    }
}
