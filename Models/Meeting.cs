
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managemate.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public string Agenda { get; set; }
        public DateTime Date { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        public virtual ICollection<MeetingParticipant> Participants { get; set; }
    }
}