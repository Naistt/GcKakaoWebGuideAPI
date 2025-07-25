using GcKakaoWebGuideAPI.Domain.Entities;

namespace GcKakaoWebGuideAPI.Domain.Interfaces;

public interface IHeroiRepository
{
    Task<List<Heroi>> GetAllAsync();
    Task<Heroi> GetByIdAsync(string id);
    Task CreateAsync(Heroi heroi);
    Task UpdateAsync(Heroi heroi);
    Task DeleteAsync(string id);
}