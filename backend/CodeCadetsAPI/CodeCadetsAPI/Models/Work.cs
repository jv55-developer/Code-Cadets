using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCadetsAPI.Models
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        [Required]
        public string Activity {  get; set; } = string.Empty;
        [Required]
        public int HoursWorked { get; set; }
        
        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
