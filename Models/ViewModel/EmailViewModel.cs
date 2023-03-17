using Arch_lab.Models.Enum;

namespace Arch_lab.Models.ViewModel
{
    public class EmailViewModel
    {
        public int EmailId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        public string Email { get; set; }

        public DateTime Dated { get; set; }

        public EmailStatus EmailStatus { get; set; }
    }
}
