using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernotEntities
{    [Table("categories")]

    public class category :myEntitiesBase
    {
        [Required , StringLength(50)]
        public string title { get; set; }

        [StringLength(150)]
        public string description { get; set; }

        public virtual List<note> Notes { get; set; }
        
        public category()
        {
            Notes = new List<note>();


        }
    }
}
