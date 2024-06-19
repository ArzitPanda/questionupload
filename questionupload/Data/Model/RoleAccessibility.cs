using questionupload.Data.Model;

namespace questionupload.Data.Model
{
    public class RoleAccessibility
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long AccessibilityId { get; set; }
        public Accessibility Accessibility { get; set; }
    }

}