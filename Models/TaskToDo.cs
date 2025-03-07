using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managemate.Models
{
    public class TaskToDo
    {
        [Key]
        [Required]
        public string TaskId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string Description { get; set; }
        public string SkillsNeeded { get; set; }
        public STATUSENUM Status { get; set; }
        public string CreatedById { get; set; }
        public int? Rating { get; set; }
        public string? Review { get; set; }

        [ForeignKey("CreatedById")]
        public virtual User Creator { get; set; }
        public virtual ICollection<UserTask> AssignedUsers { get; set; }
    }

    public enum STATUSENUM
    {
        UnAssigned, InProgress, Complete, Reviewed
    }
}