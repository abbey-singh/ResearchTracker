using System.ComponentModel.DataAnnotations;

namespace ResearchTrackerApi.Dtos
{
    public class UpdateResearchProjectDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ResearcherName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }
    }
}
