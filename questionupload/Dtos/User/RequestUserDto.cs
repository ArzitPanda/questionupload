using System.ComponentModel.DataAnnotations;

namespace questionupload.Dtos.User
{
    public class RequestUserDto
    {

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        = string.Empty;
        public string Password { get; set; }

        public string Location { get; set; }

        public DateTime? Dob { get; set; }

        [MaxLength(255)]
        public string College { get; set; }

        [MaxLength(255)]
        public string Qualification { get; set; }

    }
}
