using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernotEntities
{     [Table("notes")]

    public class note  :myEntitiesBase
    {
        [Required, StringLength(60)]
        public string title { get; set; }

        [Required, StringLength(2000)]
        public string text { get; set; }

        public bool isDraft { get; set; }

        public int likeCount { get; set; }

        public int categoryId { get; set; }

        public virtual evernoteUser owner { get; set; }

        public virtual category Category { get; set; }

        public virtual List<comment> Comments { get; set; }

        public virtual List<liked> Likes { get; set; }

        public note()
        {
            Comments = new List<comment>();
            Likes = new List<liked>();
        }
    }
}
