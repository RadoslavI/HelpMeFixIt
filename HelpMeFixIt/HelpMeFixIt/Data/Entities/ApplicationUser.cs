using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Announcements = new HashSet<Announcement>();
            Opinions = new HashSet<Opinion>();
            Comments = new HashSet<Comment>();
        }

        [Required]
        public string FullName { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
