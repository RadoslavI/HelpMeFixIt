using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
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
        public string FirstName { get; set; }

        public string LastName { get; set; }

		public string ImagePath { get; set; }

        public bool IsFixer { get; set; } = false;
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(Microsoft.AspNet.Identity.UserManager<ApplicationUser> manager)
        {
           var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
           userIdentity.AddClaim(new Claim("avatar", this.Avatar));
           return userIdentity;
        }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
