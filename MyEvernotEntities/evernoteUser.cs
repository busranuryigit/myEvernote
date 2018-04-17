using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernotEntities
{
    [Table("evernoteUsers")]
    public class evernoteUser : myEntitiesBase

    {   [StringLength(25)]
        public string name { get; set; }

        [StringLength(25)]
        public string surname { get; set; }

        [Required ,StringLength(25)]
        public string userName { get; set; }

        [Required, StringLength(70)]
        public string eMail { get; set; }

        [Required, StringLength(25)]
        public string password { get; set; }

        [StringLength(30)]
        public string profileImageFileName { get; set; }

        public bool ısActive { get; set; }

        [Required]
        public Guid activeGuid { get; set; }

        [Required]
        public bool isAdmin { get; set; }

        public virtual List<note> Notes { get; set; }

        public virtual List<comment> Comments { get; set; }

        public virtual List<liked> Likes { get; set; }
    }
}
