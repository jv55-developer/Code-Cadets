using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace CodeCadetsAPI.Models
{
    [PrimaryKey(nameof(LogId), nameof(UserId))]
    public class ProjectManagement
    {
        [ForeignKey("LogId")]
        [Required]
        
        public int LogId { get; set; }
        [ForeignKey("UserID")]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ProjectRole {  get; set; } = string.Empty;
        [ForeignKey("WorkID")]
        [Required]
        public int WorkId { get; set; }
    }
}
