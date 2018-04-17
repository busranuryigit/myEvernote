using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myEvernoteWebApp.viewModel
{
    public class okeyViewModel:notifyViewModelBase<string>
    {
        public okeyViewModel()
        {
            title = "İşlem başarılı";
        }
    }
}