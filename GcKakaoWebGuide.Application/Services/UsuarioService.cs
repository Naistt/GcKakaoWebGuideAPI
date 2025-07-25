using GcKakaoWebGuideAPI.Domain.Entities;
using GcKakaoWebGuideAPI.Domain.Interfaces;
using GcKakaoWebGuideAPI.Infrastructure.Persistence;
using MongoDB.Driver;

namespace GcKakaoWebGuideAPI.Application.Services;

public class UsuarioService(IUsuarioRepository repository)
{
    private readonly IUsuarioRepository _repository = repository;

    public Task<List<Usuario>> ObterTodos()
    {
        return _repository.GetAllAsync();
    }

    public Task Criar(Usuario usuario) => _repository.CreateAsync(usuario);
}
