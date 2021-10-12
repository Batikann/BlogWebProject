using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
    public class RegisterController : Controller
    {
        private AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        public IActionResult Index()
        {
            ViewBag.cities = GetCityList();
            return View();
        }


        [HttpPost]
        public IActionResult Index(Author author,string passwordAgain,string cities)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid && author.AuthorPassword == passwordAgain)
            {
                authorManager.Add(author);
            }
            else if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("AuthorPassword","Girdiğiniz Şifreler Eşleşmedi Tekrar Deneyiniz.");
            }
            

            return View();
        }



        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> adminRole=(from x in GetCity()
                                            select new SelectListItem
                                            {
                                                Text = x,
                                                Value = x
                                            }).ToList();

            return adminRole;
        }

        public List<String> GetCity()
        {
            String[] CitiesArray = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            return new List<string>(CitiesArray);
        }
    }
}
