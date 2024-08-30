using System.ComponentModel.DataAnnotations;

namespace CodeCadetsAPI.Models
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        [Required]
        public string Activity {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
