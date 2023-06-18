using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ChatState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;
    }
}
