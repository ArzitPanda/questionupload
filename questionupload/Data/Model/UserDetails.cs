using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace questionupload.Data.Model
{
    public class UserDetails
    {
        [Key, ForeignKey("User")]
        public long UserId { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        public DateTime? Dob { get; set; }

        [MaxLength(255)]
        public string College { get; set; }

        [MaxLength(255)]
        public string Qualification { get; set; }

        public User User { get; set; }
    }
}