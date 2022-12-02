using System.ComponentModel.DataAnnotations;
using static HelpMeFixIt.Data.DataConstants.Category;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Anouncements = new HashSet<Announcement>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Announcement> Anouncements { get; set; }
    }
}
