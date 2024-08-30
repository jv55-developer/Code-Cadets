using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCadetsAPI.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        [ForeignKey(nameof(Work))]
        [Required]
        public int WorkID { get; set; }

        public Work Work { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int UserID { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime Start {  get; set; }
        [Required]
        public DateTime End { get; set; }
        public int HoursWorked { get; set; }


    }
}
