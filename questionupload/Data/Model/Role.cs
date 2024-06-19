using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace questionupload.Data.Model
{



    public class Role
    {
        [Key]
        public long RoleId { get; set; }

        [Required]
        [MaxLength(255)]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<RoleAccessibility> RoleAccessibilities { get; set; }
    }

}