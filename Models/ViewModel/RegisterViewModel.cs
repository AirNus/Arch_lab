using System.ComponentModel.DataAnnotations;

namespace Arch_lab.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите Имя")]
        [MaxLength(20,ErrorMessage ="Имя должно иметь длину меньше 20 символов")]
        [MinLength(3,ErrorMessage ="Имя должно иметь длину больше 3 символов")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите Пароль")]
        [MinLength(3, ErrorMessage = "Пароль должен иметь длину больше 3 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите Пароль")]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
