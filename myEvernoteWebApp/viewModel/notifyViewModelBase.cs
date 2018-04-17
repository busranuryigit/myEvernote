using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myEvernoteWebApp.viewModel
{
    public class notifyViewModelBase<T>
    {
        public List<T> items { get; set; }
        public string header { get; set; }
        public string title { get; set; }
        public bool isRedirecting { get; set; }
        public string redirectingUrl { get; set; }
        public int redirectingTimeOut { get; set; }

        public notifyViewModelBase()
        {
            header = "Yönlendiriliyorsunuz";
            title = "Geçersiz İşlem";
            isRedirecting = true;
            redirectingUrl = "/Home/Index";
            redirectingTimeOut = 1000;
            items = new List<T>();
        }

    }
}