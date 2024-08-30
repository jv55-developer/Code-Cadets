using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCadetsAPI.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        [ForeignKey("WorkId")]
        [Required]
        public int WorkID { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserID { get; set; }
        [Required]
        public DateTime Start {  get; set; }
        [Required]
        public DateTime End { get; set; }
        public int HoursWorked { get; set; }


    }
}
