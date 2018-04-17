using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernotEntities
{    [Table("comments")]
    public class comment  :myEntitiesBase

    {   [Required ,StringLength(300)]
        public string text { get; set; }

        public virtual note Notes { get; set; }

        public virtual evernoteUser Owner { get; set; }

    }
}
