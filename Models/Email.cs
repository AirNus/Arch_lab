using Arch_lab.Models.Enum;

namespace Arch_lab.Models
{
    public class Email
    {
        public int Id { get; set; }

        public DateTime Dated { get; set; }
        
        public int IdSender { get; set; }

        public string Data { get; set; }

        public byte[]? Signature { get; set; }

        public int IdReceiver { get; set; }

        public EmailStatus Status { get; set; }

    }
}
