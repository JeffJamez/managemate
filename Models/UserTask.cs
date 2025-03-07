
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Managemate.Models
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        public string AssignedEmployeeId { get; set; }
        public string TaskId { get; set; }

        [ForeignKey("AssignedEmployeeId")]
        public virtual User AssignedEmployee { get; set; }

        [ForeignKey("TaskId")]
        public virtual TaskToDo TasksToDo { get; set; }
    }
}