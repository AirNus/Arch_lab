using System.ComponentModel.DataAnnotations;

namespace Arch_lab.Models.Enum
{
    public enum EmailStatus
    {
        [Display(Name="Неподписанное")]
        Unsign = 1,
        [Display(Name = "Подписанное")]
        Sign = 2
    }
}
