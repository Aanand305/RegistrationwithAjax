using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationwithAjax.Models;
using RegistrationwithAjax.ViewModel;
using System.IO;
using System.Linq;

namespace RegistrationwithAjax.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext dbContext;
        private IWebHostEnvironment environment;
        public AccountController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            this.dbContext = dbContext;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var data = dbContext.employees.ToList();
            return View(data);
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Image/" + model.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(model.ImagePath, fullPath);
                var data = new Employee()
                {
                    Name = model.Name,
                    Email=model.Email,
                    Gender=model.Gender,
                    Password=model.Password,
                    ImagePath = fullPath,
                };
                dbContext.Add(data);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }

        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
