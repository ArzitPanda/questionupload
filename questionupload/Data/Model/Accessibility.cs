using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace questionupload.Data.Model
{

    public class Accessibility
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string AccessibilityName { get; set; }

        public ICollection<RoleAccessibility> RoleAccessibilities { get; set; }
    }

}
