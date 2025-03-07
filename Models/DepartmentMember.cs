using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managemate.Models
{
    public class DepartmentMember
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}