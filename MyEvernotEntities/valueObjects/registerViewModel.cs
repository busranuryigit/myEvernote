using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernoteEntities.valueObjects
{
    public class registerViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage="{0} alanı boş geçilemez."), StringLength(25, ErrorMessage="{0} maksimum {1} karakter olmalı")]
        public string userName { get; set; }

        [DisplayName("E-Posta"), Required(ErrorMessage="{0} Alan Boş Geçilemez."), StringLength(70, ErrorMessage="{0} maksimum {1} karakter olmalı."), EmailAddress(ErrorMessage = "{0} alanına geçerli bir e-posta giriniz.")]
        public string eMail { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage ="{0} Alan Boş Geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage="{0} maksimum {1} karakter olmalı.")]
        public string password { get; set; }

       // [DisplayName("Şifre Tekrar"), Required(ErrorMessage ="{0} Alan Boş Geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage="{0} maksimum {1} karakter olmalı."), Compare("Password", ErrorMessage="{0} ile {1} uyuşmamaktadır")]
        [DisplayName("Şifre Tekrar"), Required(ErrorMessage ="{0} Alan Boş Geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage="{0} maksimum {1} karakter olmalı."), Compare("password", ErrorMessage="{0} ile {1} uyuşmamaktadır")]
        public string rePassword { get; set; }
    }
}