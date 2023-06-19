using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TelegramUser
    {
        [Key]
        public long TelegramId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        [MaxLength(500)]
        public string PhotoId { get; set; } = string.Empty;
        [ForeignKey("UserToRateId")]
        public ICollection<Rating> Ratings { get; set; }
        [Required]
        public ChatState State { get; set; }
        [Required]
        public int StateId { get; set; }
        public TelegramUser NextUserToRate{ get; set; }
        [ForeignKey("NextUserToRate")]
        public long NextUserToRateId { get; set; }
    }
}
