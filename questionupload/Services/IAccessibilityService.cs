namespace questionupload.Services
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccessibilityService
    {
        Task<Accessibility> GetAccessibilityByIdAsync(int id);
        Task<List<Accessibility>> GetAllAccessibilitiesAsync();
        Task<Accessibility> CreateAccessibilityAsync(Accessibility accessibility);
        Task UpdateAccessibilityAsync(Accessibility accessibility);
        Task DeleteAccessibilityAsync(int id);
    }

}
