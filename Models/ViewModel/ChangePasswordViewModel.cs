using System.ComponentModel.DataAnnotations;

namespace Arch_lab.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(3, ErrorMessage = "Пароль должен быть больше или равен 3 символов")]
        public string NewPassword { get; set; }

    }
}
