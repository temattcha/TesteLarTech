using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace API.Models
{
    // Principal (parent)
    public class User(Guid Id, String? Name, String Username, String Password, String? CPF, String? Birthday)
    {
        public Guid Id { get; set; } = Id;
        public String? Name { get; set; } = Name;
        public String Username { get; set; } = Username;
        public String Password { get; set; } = Password;
        public String? CPF { get; set; } = CPF;
        public String? Birthday { get; set; } = Birthday;
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Phone> Phones { get; } = [];
    }

    // Dependent (child)
    public class Phone(Guid Id, String Number, Guid UserId)
    {
        public Guid Id { get; set; } = Id;
        public String Number { get; set; } = Number;
        public PhoneTypes PhoneType { get; set; } = PhoneTypes.mobile;

        public enum PhoneTypes{
            commercial,
            mobile,
            residential
        }

        [ForeignKey("User")]
        public Guid UserId { get; set; } = UserId;

        public virtual User User { get; set; } = null!;
    }

    // Cat
    public class Cat()
    {
        public int id { get; set; }
        public string author { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
        public string src { get; set; } = string.Empty;
        public string peso { get; set; } = string.Empty;
        public string idade { get; set; } = string.Empty;
        public string acessos { get; set; } = string.Empty;
        public string total_comments { get; set; } = string.Empty;
    }
}
