using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HelpMeFixIt.Data.DataConstants.Opinion;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class Opinion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; }

        [Range(0, 5)]
        public short Rating { get; set; }

        public int FixerId { get; set; }
        [ForeignKey(nameof(FixerId))]
        public Fixer Fixer { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

    }
}
