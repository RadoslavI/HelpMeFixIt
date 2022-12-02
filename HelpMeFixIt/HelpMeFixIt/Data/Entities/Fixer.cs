using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HelpMeFixIt.Data.DataConstants.Fixer;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class Fixer
    {
        public Fixer()
        {
            Opinions = new HashSet<Opinion>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }

    }
}
