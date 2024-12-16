using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace iranAttractions.ViewModels
{
    public class LoginViewModel
    {
      
        [Key]
        public int Id { get; set; }



        
        [Required(ErrorMessage = "لطفا ایمیل خود وارد کنید  ")]
        [Display(Name = "ایمیل ")]
        public string phonenumber    { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا رمز عبور وارد کنید  ")]
        [StringLength(maximumLength:8 ,MinimumLength =8, ErrorMessage ="رمز عبور باید 8 رقمی باشد")]
        [Display(Name = "رمز عبور ")]
        public string password { get; set; }

        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { get; set; }
        
    }


}
