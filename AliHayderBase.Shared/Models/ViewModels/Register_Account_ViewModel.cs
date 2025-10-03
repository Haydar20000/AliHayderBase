using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Shared.Models.ViewModels
{
    public class Register_Account_ViewModel
    {
        [Required(ErrorMessage = "يجب كتابة اسم تسجيل الدخول")]
        [Display(Name = "أسم تسجيل الدخول")]
        //[Remote(action: "IsUserNameInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "يجب كتابة الاسم الثلاثي رجاءا")]
        [Display(Name = "أسم المستخدم الثلاثي")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "يجب تحديد المهنة رجاءا")]
        [Display(Name = "المهنة")]
        public string Job { get; set; }

        [Required(ErrorMessage = "يجب كتابة البريد الاكتروني ")]
        [EmailAddress(ErrorMessage = "يجب كتابة البريد الاكتروني بالطريقة الصحيحة")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = " البريد الاكتروني")]
        //[Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "كلمة السر يجب ان تتكون من 8 احرف على الاقل رجاءا", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(256, ErrorMessage = "كلمة السر غير متطابقة رجاءا ..", MinimumLength = 8)]
        [Display(Name = "تاكيد كلمة السر")]
        [Compare("Password",
            ErrorMessage = "كلمة السر غير متطابقة رجاءا ..")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "يجب تحديد رقم الهاتف رجاءا")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "رقم الهوية النقابية")]
        public string IdNumber { get; set; }

        [Display(Name = "رقم الهاتف المثبت في استمارة التسجيل")]
        public string RPhoneNumber { get; set; }
    }
}