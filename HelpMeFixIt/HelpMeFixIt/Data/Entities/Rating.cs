using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace HelpMeFixIt.Data.Entities
{
    public class Rating
    {
        public double TotalRating { get; set; }

        public int FixerId { get; set; }
        [ForeignKey(nameof(FixerId))]
        public Fixer Fixer { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
