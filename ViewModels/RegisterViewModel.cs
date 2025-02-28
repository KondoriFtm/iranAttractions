﻿using System.ComponentModel.DataAnnotations;

namespace iranAttractions.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "لطفا شماره تماس خود وارد کنید  ")]
        [Display(Name = "شماره تماس ")]
        [Phone(ErrorMessage ="شماره تماس وارد شده معتبر نمی باشد")]
        [StringLength(maximumLength:11, MinimumLength = 11, ErrorMessage = "شماره تماس باید 11 رقمی باشد")]

        public string phonenumber { get; set; }


        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [MaxLength(50)]
        public string username { get; set; }



        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا رمز عبور وارد کنید  ")]
        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "رمز عبور باید 8 رقمی باشد")]
        [Display(Name = "رمز عبور ")]
        public string password { get; set; }

        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "رمز عبور باید 8 رقمی باشد")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا رمز عبور وارد کنید  ")]
        [Display(Name = "تکرار رمز عبور ")]
        //[Compare(password,ErrorMessage = 'رمز عبور با تککرار آن مطابقت ندارد')]
        public string Repeatpassword { get; set; }
    }
}
