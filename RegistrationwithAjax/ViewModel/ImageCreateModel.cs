using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RegistrationwithAjax.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "please Enter Your Gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Password Mandatory")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please Choose Image/file")]
        [Display(Name = "Choose Image")]
        public IFormFile ImagePath { get; set; }

    }
}
