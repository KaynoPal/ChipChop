using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace chipchop.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا شماره موبایل خود را وارد کنید")]
        [MinLength(11, ErrorMessage = "حداقل 11 رفم")]
        [MaxLength(11, ErrorMessage = "حداکثر 11 رقم")]
        [Display(Prompt = "شماره موبایل")]
        [DataType(DataType.PhoneNumber)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "لطفا رمز خود را وارد کنید")]
        [MinLength(8, ErrorMessage = "حداقل 8 کارکتر")]
        [MaxLength(12, ErrorMessage = "حداکثر 12 کارکتر")]
        [DataType(DataType.Password)]
        [Display(Prompt = "رمز")]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا رمز مجدد را وارد کنید")]
        [MinLength(8, ErrorMessage = "حداقل 8 کارکتر")]
        [MaxLength(12, ErrorMessage = "حداکثر 12 کارکتر")]
        [DataType(DataType.Password)]
        [Display(Prompt = "تکرار رمز")]
        [Compare(nameof(Password), ErrorMessage ="رمز ها هم خوانی ندارند")]
        public string RePassword { get; set; }
    }
}
