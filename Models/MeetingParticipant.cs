using System.ComponentModel.DataAnnotations;

namespace Managemate.Models
{
    public class MeetingParticipant
    {
        [Key]
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public string ParticipantId { get; set; }
        public bool NotificationSent { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual User Participant { get; set; }
    }
}