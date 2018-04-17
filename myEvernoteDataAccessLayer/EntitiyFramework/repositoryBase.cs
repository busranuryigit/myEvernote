using myEvernoteDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteDataAccessLayer.EntityFramework
{
    public class repositoryBase
    {
        //private static databaseContext _db;
        protected static databaseContext context;
        protected static object _lockSync= new object();

        protected repositoryBase()
        {
            CreateContext();
        }

        public static void CreateContext()
        {
            if (context==null)
            {
                lock (_lockSync)
                {
                    if (context==null)
                    {
                        context = new databaseContext();
                    }
                }
               
            }
           
        }
    }
}
