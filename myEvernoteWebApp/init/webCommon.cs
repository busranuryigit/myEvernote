using myEvernoteCommon;
using MyEvernotEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myEvernoteWebApp.init
{
    public class webCommon : iCommon
    {
        public string GetUserName()
        {
            if (HttpContext.Current.Session["login"]!=null)
            {
                evernoteUser user = HttpContext.Current.Session["login"] as evernoteUser;
                return user.userName;
            

            }
            return null;
        }
    }
}