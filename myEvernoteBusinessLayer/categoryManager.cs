using myEvernoteDataAccessLayer.EntityFramework;
using MyEvernotEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteBusinessLayer
{
    public class categoryManager
    {
        private repository<category> repoCategory = new repository<category>();

        public List<category> getCategories()
        {
            return repoCategory.list();
        }

        public category getCategoryById(int id )
        {
            return repoCategory.find(x => x.id==id);
        }
    }
}
