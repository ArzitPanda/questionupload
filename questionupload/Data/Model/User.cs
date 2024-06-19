using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace questionupload.Data.Model
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public UserDetails UserDetails { get; set; }
    }

}
