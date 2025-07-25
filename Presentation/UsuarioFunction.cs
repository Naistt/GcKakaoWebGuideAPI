using GcKakaoWebGuideAPI.Application.Interfaces;
using GcKakaoWebGuideAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GcKakaoWebGuideAPI.Presentation;

public class UsuarioFunction(IUsuarioService usuarioService)
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    [Function("ObterUsuarios")]
    public async Task<HttpResponseData> ObterUsuarios(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "usuarios")] HttpRequestData req)
    {
        var usuarios = await _usuarioService.ObterTodos();
        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await response.WriteAsJsonAsync(usuarios);
        return response;
    }

    [Function("CriarUsuario")]
    public async Task<HttpResponseData> CriarUsuario(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "usuarios")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(requestBody);

        var novoUsuario = await _usuarioService.Criar(usuario);
        var response = req.CreateResponse(System.Net.HttpStatusCode.Created);
        await response.WriteAsJsonAsync(novoUsuario);
        return response;
    }
}
