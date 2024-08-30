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
        [ForeignKey(nameof(Log))]
        [Required]
        public int LogId { get; set; }
        public Log Log { get; set; }
        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string ProjectRole {  get; set; } = string.Empty;
        [ForeignKey(nameof(Project))]
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
