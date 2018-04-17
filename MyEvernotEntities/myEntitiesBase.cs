using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteEntities
{
       public class myEntitiesBase    
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public int id { get; set; }

        [Required]
        public DateTime createdOn { get; set; }

        [Required]
        public DateTime modifiedOn { get; set; }

        [Required , StringLength(30)]
        public string modifiedUserName { get; set; }
    }
}
