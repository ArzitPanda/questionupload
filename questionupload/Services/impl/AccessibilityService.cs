namespace questionupload.Services.impl
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AccessibilityService : IAccessibilityService
    {
        private readonly IAccessibilityRepository _accessibilityRepository;

        public AccessibilityService(IAccessibilityRepository accessibilityRepository)
        {
            _accessibilityRepository = accessibilityRepository;
        }

        public async Task<Accessibility> GetAccessibilityByIdAsync(int id)
        {
            return await _accessibilityRepository.GetByIdAsync(id);
        }

        public async Task<List<Accessibility>> GetAllAccessibilitiesAsync()
        {
            return await _accessibilityRepository.GetAllAsync();
        }

        public async Task<Accessibility> CreateAccessibilityAsync(Accessibility accessibility)
        {
            return await _accessibilityRepository.AddAsync(accessibility);
        }

        public async Task UpdateAccessibilityAsync(Accessibility accessibility)
        {
            await _accessibilityRepository.UpdateAsync(accessibility);
        }

        public async Task DeleteAccessibilityAsync(int id)
        {
            var accessibility = await _accessibilityRepository.GetByIdAsync(id);
            if (accessibility != null)
            {
                await _accessibilityRepository.DeleteAsync(accessibility);
            }
        }
    }

}
