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

namespace BlogProject.Controllers
{
    public class RegisterController : Controller
    {
        private AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Author author,string passwordAgain)
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
    }
}
