using System.ComponentModel.DataAnnotations;

namespace Managemate.Models
{
    public class User
    {
        [Key]
        // [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public UserType UserType { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string? Skills { get; set; }
        public DateTime JoinedOn { get; set; }
        public int? Otp { get; set; }
        public int MinWorkingHours { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public virtual ICollection<TaskToDo> CreatedTasks { get; set; }
        public virtual ICollection<UserTask> AssignedTasks { get; set; }
        public virtual ICollection<MeetingParticipant> Meetings { get; set; }
        public virtual ICollection<WorkLog> WorkLogs { get; set; }
        // The meetings that a user has created
        public virtual ICollection<Meeting> MeetingsCreated { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, UserType: {UserType}, Email: {Email}, Skills: {Skills}, JoinedOn: {JoinedOn}, MinWorkingHours: {MinWorkingHours}";
        }
    }

    public enum UserType
    {
        TaskManager, Admin, Employee
    }
}