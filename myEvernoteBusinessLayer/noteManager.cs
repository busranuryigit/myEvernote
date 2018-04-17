using myEvernoteDataAccessLayer.EntityFramework;
using MyEvernotEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteBusinessLayer
{
    public class noteManager
    {
        private repository<note> repoNote = new repository<note>();

         public List<note> getAllNote()
        {
            return repoNote.list();
        }

    }
}
