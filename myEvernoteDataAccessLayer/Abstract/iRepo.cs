using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteDataAccessLayer.Abstract
{
    interface iRepo<T>
    {
        List<T> list();



         List<T> list(Expression<Func<T, bool>> where);


          int insert(T obj);



        int update(T obj);



        int delete(T obj);


        int save();


        T find(Expression<Func<T, bool>> where);


    }
}
