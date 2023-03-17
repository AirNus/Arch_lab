namespace Arch_lab.Models
{
    public class Certificate
    {
        public int Id { get; set; }

        public string CertName { get; set; }

        public int PublicKeyId {get; set; }

        public int PrivateKeyId { get; set; }

        public bool Actual { get; set; }
    }
}
