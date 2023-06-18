using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public TelegramUser User { get; set; }
        [Required]
        public long TelegramUserId { get; set; }
        [Required]
        public int RatingNumber { get; set; }
        //TODO add isChecked
    }
}
