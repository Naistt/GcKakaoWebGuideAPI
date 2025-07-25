using GcKakaoWebGuideAPI.Domain.Entities;
using GcKakaoWebGuideAPI.Application.Interfaces;
using GcKakaoWebGuideAPI.Domain.Interfaces;

namespace GcKakaoWebGuideAPI.Application.Services;

public class HeroiService(IHeroiRepository repository) : IHeroiService
{
    private readonly IHeroiRepository _repository = repository;

    public Task<List<Heroi>> ObterTodos() => _repository.GetAllAsync();
    public Task<Heroi> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
    public Task Criar(Heroi heroi) => _repository.CreateAsync(heroi);
    public Task Editar(Heroi heroi) => _repository.UpdateAsync(heroi);
    public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
}
