using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernoteEntities.valueObjects
{
    public class loginViewModel

    {
        [DisplayName("Şifre"), Required(ErrorMessage = " {0} Alan Boş Geçilemez"),  StringLength(25, ErrorMessage = " {0} maksimum {1} karakter olmalı")]

        public string userName { get; set; }


        [DisplayName("Şifre"), Required(ErrorMessage = " {0} Alan Boş Geçilemez") , DataType(DataType.Password),StringLength(25, ErrorMessage = " {0} maksimum {1} karakter olmalı")]
     
        public string password { get; set; }
    }
}