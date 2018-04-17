using myEvernoteBusinessLayer;
using MyEvernoteEntities.errorMessage;
using MyEvernoteEntities.valueObjects;
using MyEvernotEntities;
using myEvernoteWebApp.viewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace myEvernoteWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            noteManager nm = new noteManager();
            return View(nm.getAllNote().OrderByDescending(x => x.modifiedOn).ToList());
        }

        // GET: category
        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            categoryManager cm = new categoryManager();
            category cat = cm.getCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View("Index", cat.Notes.OrderByDescending(x => x.modifiedOn).ToList());
        }

        //GET:Most Liked
        public ActionResult MostLiked()
        {
            noteManager nm = new noteManager();
            return View("Index", nm.getAllNote().OrderByDescending(x => x.likeCount).ToList());
        }

        //GET:About
        public ActionResult ShowProfile()
        {
            evernoteUser currentUser = Session["login"] as evernoteUser;
            userManager um = new userManager();
            businessLayerResult<evernoteUser> layerResult = um.getUserById(currentUser.id);
            if (layerResult.errorMessage.Count>0)
            {
                errorViewModel errorNotifyObj = new errorViewModel()
                {
                    title = "Hata Oluştu",
                    items = layerResult.errorMessage

                };

                return View("error", errorNotifyObj);
            }
            return View(layerResult.result);
        }

        public ActionResult EditProfile()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(evernoteUser user)
        {

            return View();
        }

        public ActionResult RemoveProfile()
        {

            return View();
        }

        public ActionResult About()
        {

            return View();
        }
         
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                userManager um = new userManager();
                businessLayerResult<evernoteUser> res = um.loginUser(model);


                if (res.errorMessage.Count > 0)
                {
                    if (res.errorMessage.Find(x => x.code == errorMessageCode.userIsNotActive) != null)
                    {
                        ViewBag.SetLink = "https://Home/Activate/123-456-7890";
                    }
                    res.errorMessage.ForEach(x => ModelState.AddModelError("", x.errorMessage));
                    return View(model);
                }
                Session["login"] = res.result;
                return RedirectToAction("Index");
            }


            return View(model);
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(registerViewModel model)
        {
            if (ModelState.IsValid)
            {
                userManager eum = new userManager();
                businessLayerResult<evernoteUser> res = eum.registerUser(model);

                if (res.errorMessage.Count > 0)
                {
                    res.errorMessage.ForEach(x => ModelState.AddModelError("", x.errorMessage));
                    return View(model);
                }



                //evernoteUser user = null;

                //try
                //{
                //    user=eum.registerUser(model);
                //}
                //catch (Exception ex)
                //{

                //    ModelState.AddModelError("", ex.Message);
                //}

                //if (model.userName=="aaa")
                //{
                //    ModelState.AddModelError("", "Kullanıcı Adı Kullanılıyor");
                //}
                //if (model.eMail == "aaa@aaa.com")
                //{
                //    ModelState.AddModelError("", "E-Posta Adresi  Kullanılıyor");
                //}
                //foreach (var item in ModelState)
                //{
                //    if (item.Value.Errors.Count>0)
                //    {
                //        return View(model);
                //    }
                //}
                //if (user==null)
                //{
                //    return View(model);
                //}

                okeyViewModel notifyObj = new okeyViewModel()
                {
                    title = "Kayıt Başarılı",
                    redirectingUrl="/Home/Login",
                     
                };
                notifyObj.items.Add("Lütfen E-posta adresine gönderdiğimiz aktivasyon kodunu onaylayınız . Aksi takdirde hesabınız aktivite edilmeden not ekleyemez ve beğenme işlemlerini gerçekleştiremezsiniz.");

                return View("Okey",notifyObj);

            }

            return View(model);
        }

        public ActionResult UserActivate(Guid activateId)
        {
            userManager um = new userManager();
            businessLayerResult<evernoteUser> layerResult = um.activateUser(activateId);

            if (layerResult.errorMessage.Count > 0)
            {
                errorViewModel errorNotifyObj = new errorViewModel()
                {
                    title = "Geçersiz İşlem",
                    items = layerResult.errorMessage

                };

                return View("error", errorNotifyObj);
            }

            okeyViewModel okNotifyObj = new okeyViewModel()
            {
                title="Hesap Aktifleştirildi",
                redirectingUrl="/Home/Login",
              
            };
            okNotifyObj.items.Add("Hesabınız aktifleştirildi. Artık not paylaşabilir ve beğenme işlemini gerçekleştirebilirsiniz.");

            return View("Okey",okNotifyObj);
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }
    }
}