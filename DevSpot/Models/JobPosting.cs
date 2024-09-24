using System.ComponentModel.DataAnnotations;

namespace DevSpot.Models
{
    public class JobPosting
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
    }
}
