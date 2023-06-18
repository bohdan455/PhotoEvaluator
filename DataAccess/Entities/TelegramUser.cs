using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<Rating> Ratings { get; set; }
        [Required]
        public ChatState State { get; set; }
    }
}
