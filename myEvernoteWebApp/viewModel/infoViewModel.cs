using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myEvernoteWebApp.viewModel
{
    public class infoViewModel :notifyViewModelBase<string>
    {
        public infoViewModel()
        {
            title = "Bilgilendirme";
        }
    }
}