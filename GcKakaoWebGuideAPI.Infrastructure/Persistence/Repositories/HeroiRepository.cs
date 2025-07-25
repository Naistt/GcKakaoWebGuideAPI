using AutoMapper;
using GcKakaoWebGuideAPI.Domain.Entities;
using GcKakaoWebGuideAPI.Domain.Interfaces;
using GcKakaoWebGuideAPI.Infrastructure.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GcKakaoWebGuideAPI.Infrastructure.Persistence.Repositories;

public class HeroiRepository : IHeroiRepository
{
    private readonly IMongoCollection<HeroiDocument> _heroiCollection;
    private readonly IMapper _mapper;

    public HeroiRepository(IOptions<MongoSettings> config, IMapper mapper)
    {
        var client = new MongoClient(config.Value.ConnectionString);
        var db = client.GetDatabase(config.Value.DatabaseName);
        _heroiCollection = db.GetCollection<HeroiDocument>("Herois");
        _mapper = mapper;
    }
    public async Task<List<Heroi>> GetAllAsync()
    { 
        var heroiDocs = await _heroiCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<Heroi>>(heroiDocs);
    }
    public async Task<Heroi> GetByIdAsync(string id)
    {
        var heroiDoc = await _heroiCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<Heroi>(heroiDoc);
    }
    public async Task CreateAsync(Heroi heroi)
    {
        var heroiDocToCreate = _mapper.Map<HeroiDocument>(heroi);
        await _heroiCollection.InsertOneAsync(heroiDocToCreate);
    }
    public async Task UpdateAsync(Heroi heroi) {
        var result = await _heroiCollection.ReplaceOneAsync(_ => _.Id == heroi.Id, _mapper.Map<HeroiDocument>(heroi));

        // Verifica se houve correspondência para a atualização
        if (result.MatchedCount == 0)
            throw new Exception("Falha ao atualizar o herói.");
    } 
    public async Task DeleteAsync(string id) => await _heroiCollection.DeleteOneAsync(_ => _.Id == id);
}