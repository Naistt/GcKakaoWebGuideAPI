using GcKakaoWebGuideAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using GcKakaoWebGuideAPI.Application.Interfaces;

namespace GcKakaoWebGuideAPI.Presentation;
public class HeroiFunction(IHeroiService heroiService) // conceito de construtor primário: declaração da classe e construtor junto
{
    private readonly IHeroiService _heroiService = heroiService;

    [Function("ObterHerois")]
    public async Task<HttpResponseData> ObterHerois(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "heroes")] HttpRequestData req)
    {
            
        var herois = await _heroiService.ObterTodos();
        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);

        if (herois == null || herois.Count == 0)
            response.StatusCode = System.Net.HttpStatusCode.NoContent;
        else
            await response.WriteAsJsonAsync(herois);
        
        return response;
    }

    [Function("CriarHeroi")]
    public async Task<HttpResponseData> CriarHeroi(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "heroes")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var heroi = Newtonsoft.Json.JsonConvert.DeserializeObject<Heroi>(requestBody);

        await _heroiService.Criar(heroi);
        var response = req.CreateResponse(System.Net.HttpStatusCode.Created);
        return response; // tirar
        await response.WriteAsJsonAsync(heroi);
        return response;
    }

    [Function("EditarHeroi")]
    public async Task<HttpResponseData> EditarHeroi(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "heroes")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var heroi = Newtonsoft.Json.JsonConvert.DeserializeObject<Heroi>(requestBody);

        await _heroiService.Editar(heroi);
        var response = req.CreateResponse(System.Net.HttpStatusCode.Created);
        return response; // tirar
        await response.WriteAsJsonAsync(heroi);
        return response;
    }
}
