using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.API.Models.Db
{
    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

    }
}
