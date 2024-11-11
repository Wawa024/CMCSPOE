using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace CMCSPOE.Models
{
    public class ClaimViewModel
    {
        public int Id { get; set; }


        public int LecturerId { get; set; }

        public decimal HoursWorked { get; set; }

 
        public decimal HourlyRate { get; set; }

        public string? AdditionalNotes { get; set; }
        public string? Status { get; set; } // "Pending", "Approved", "Rejected"
        public string? SupportingDocument { get; set; }
        public string? Description { get; set; }

        public string? ClaimValue { get; set; }

        public DateTime DateCreated { get; set; }

        public string LectureName { get; set; }

    }
}
