using GcKakaoWebGuideAPI.Domain.Entities;

namespace GcKakaoWebGuideAPI.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(string id);
    Task CreateAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(string id);
}