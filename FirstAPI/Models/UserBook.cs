using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class UserBook
    {
        [Key]
        public string UserName { get; set; }

        [ForeignKey("Book")]
        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
