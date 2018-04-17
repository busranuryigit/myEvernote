using myEvernoteCommon.helpers;
using myEvernoteDataAccessLayer.EntityFramework;
using MyEvernoteEntities.errorMessage;
using MyEvernoteEntities.valueObjects;
using MyEvernotEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteBusinessLayer
{
    public class userManager
    {
        private repository<evernoteUser> repoUser = new repository<evernoteUser>();

        public businessLayerResult<evernoteUser> registerUser(registerViewModel data)
        {

            evernoteUser user = repoUser.find(x => x.userName == data.userName || x.eMail == data.eMail);
            businessLayerResult<evernoteUser> layerResult = new businessLayerResult<evernoteUser>();



            if (user != null)
            {
                if (user.userName == data.userName)
                {
                    layerResult.addError(errorMessageCode.userNameAlreadyExists, "Kullanıcı Adı Kayıtlı ");
                }
                if (user.eMail == data.eMail)
                {
                    layerResult.addError(errorMessageCode.eMailAlreadyExists, "Kullanıcı E-posta Kayıtlı ");
                }
            }
            else
            {
                int dbResult = repoUser.insert(new evernoteUser()
                {
                    userName = data.userName,
                    eMail = data.eMail,
                    password = data.password,
                    activeGuid = Guid.NewGuid(),
                    createdOn = DateTime.Now,
                    modifiedOn = DateTime.Now,
                    ısActive = false,
                    isAdmin = false,
                    modifiedUserName = "system"


                });
                if (dbResult > 0)
                {
                    layerResult.result = repoUser.find(x => x.eMail == data.eMail || x.userName == data.userName);

                    string siteUri = configHelper.Get<string>("SiteRootUri");
                    string activeUri = $"{siteUri} /Home/userActivate/{user.activeGuid} ";
                    string body = $"Merhaba {user.name} {user.surname};<br><br> <a href='{activeUri}' target='_blank'>tıklayınız</a>.";
                    mailHelper.SendMail(body, user.eMail, "My Evernote Hesap Aktifleştirme");
                }
            }

            return layerResult;

        }

        public businessLayerResult<evernoteUser> getUserById(int id)
        {
            businessLayerResult<evernoteUser> layerResult = new businessLayerResult<evernoteUser>();
           layerResult.result= repoUser.find(x => x.id == id);
            if (layerResult.result==null)
            {
                layerResult.addError(errorMessageCode.userNotFound, "Kullanıcı bulunamadı.");
            }
            return layerResult;

        }

        public businessLayerResult<evernoteUser> loginUser(loginViewModel data)
        {
            businessLayerResult<evernoteUser> layerResult = new businessLayerResult<evernoteUser>();
            layerResult.result = repoUser.find(x => x.userName == data.userName || x.password == data.password);



            if (layerResult != null)
            {
                if (!layerResult.result.ısActive)
                {

                    layerResult.addError(errorMessageCode.userIsNotActive, "Kullanıcı aktif edilmemiştir.");
                    layerResult.addError(errorMessageCode.checkYourEmail, "Lütfen e-posta adresinizi kontrol ediniz.");


                }

            }
            else
            {
                layerResult.addError(errorMessageCode.userNameOrPasWrong, "Kullanıcı adı ya da şifre uyuşmuyor");
            }
            return layerResult;
        }

        public businessLayerResult<evernoteUser> activateUser(Guid activateId)
        {

            businessLayerResult<evernoteUser> layerResult = new businessLayerResult<evernoteUser>();
            layerResult.result = repoUser.find(x => x.activeGuid == activateId);
            if (layerResult.result != null)
            {
                if (layerResult.result.ısActive)
                {
                    layerResult.addError(errorMessageCode.userAlreadyActive, "Kullanıcı zaten aktif edilmiştir.");
                    return layerResult;
                }
                else
                {
                    layerResult.addError(errorMessageCode.activateIdDoesNotExist, "Aktifleştirelecek kullanıcı bulunamadı.");
                }

                layerResult.result.ısActive = true;
                repoUser.update(layerResult.result);
            }
            return layerResult;
        }

    }

}
