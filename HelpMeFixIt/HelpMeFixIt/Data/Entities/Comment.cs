using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HelpMeFixIt.Data.DataConstants.Comment;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public int AnnouncementId { get; set; }
        [ForeignKey(nameof(AnnouncementId))]
        public Announcement Announcement { get; set; }
    }
}