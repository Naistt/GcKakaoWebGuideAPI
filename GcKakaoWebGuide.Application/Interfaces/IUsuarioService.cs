using GcKakaoWebGuideAPI.Domain.Entities;

namespace GcKakaoWebGuideAPI.Application.Interfaces;

public interface IUsuarioService
{
    Task<List<Usuario>> ObterTodos();
    Task<Usuario> Criar(Usuario usuario);
}