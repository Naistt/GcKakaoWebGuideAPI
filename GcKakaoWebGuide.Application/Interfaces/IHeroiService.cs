using GcKakaoWebGuideAPI.Domain.Entities;

namespace GcKakaoWebGuideAPI.Application.Interfaces;

public interface IHeroiService
{
    Task<List<Heroi>> ObterTodos();
    Task<Heroi> GetByIdAsync(string id);
    Task Criar(Heroi heroi);
    Task Editar(Heroi heroi);
    Task DeleteAsync(string id);
}