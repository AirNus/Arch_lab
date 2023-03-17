using System.ComponentModel.DataAnnotations.Schema;

namespace Arch_lab.Models
{
    public class PublicKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Key { get; set; }

        public bool Actual { get; set; }
    }
}
