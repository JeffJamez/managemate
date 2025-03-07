
using System.ComponentModel.DataAnnotations;

namespace Managemate.Models
{
    /*  public class WorkLog
     {
         [Key]
         public int Id { get; set; }
         public string EmployeeId { get; set; }
         public DateTime CheckInTime { get; set; }
         public DateTime CheckoutTime { get; set; }
         public int TotalWorkingHours { get; set; }

         public virtual User Employee { get; set; }
     } */

    public class WorkLog
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public DateTime LogDate { get; set; }
        public List<WorkSession> Sessions { get; set; } = new();
        public int TotalMinutesWorked { get; set; }

        public virtual User Employee { get; set; }
    }

    public class WorkSession
    {
        [Key]
        public int Id { get; set; }
        public int WorkLogId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckoutTime { get; set; }

        public virtual WorkLog WorkLog { get; set; }
    }
}