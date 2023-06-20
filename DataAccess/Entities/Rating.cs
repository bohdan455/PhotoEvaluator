using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public long UserToRateId { get; set; }
        public TelegramUser Rater { get; set; }
        [Required]
        [ForeignKey("Rator")]
        public long RaterId { get; set; }
        [Required]
        public int RatingNumber { get; set; }
        public bool IsChecked { get; set; }
    }
}
