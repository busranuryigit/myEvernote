using MyEvernotEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteDataAccessLayer.EntityFramework
{
    public class databaseContext :DbContext
    {
        public DbSet<evernoteUser> evernoteUsers { get; set; }
        public DbSet<comment> Comments { get; set; }
        public DbSet<note> Notes { get; set; }
        public DbSet<category> Catagories { get; set; }
        public DbSet<liked> Likes { get; set; }

        public databaseContext()
        {
            Database.SetInitializer(new myInitializer());
        }

       
    }
}
