using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myEvernoteWebApp.viewModel
{
    public class warningViewModel:notifyViewModelBase<string>
    {
        public warningViewModel()
        {
            title = "Uyarı";
        }
    }
}