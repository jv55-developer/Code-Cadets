using System.ComponentModel.DataAnnotations;

namespace CodeCadetsAPI.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime CompletionDate { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Budget { get; set; }
    }
}
