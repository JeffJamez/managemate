
using System.ComponentModel.DataAnnotations;

namespace Managemate.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DepartmentMember> Members { get; set; }
        public virtual ICollection<TaskToDo> TasksToDo { get; set; }
    }
}