using GcKakaoWebGuideAPI.Domain.Entities;
using GcKakaoWebGuideAPI.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Text.Json;

namespace GcKakaoWebGuideAPI.Infrastructure.Persistence.Models;

public class HeroiDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("nome")]
    [JsonProperty("nome")]  // A propriedade JSON e a Bson são mapeadas para "nome
    public required string Nome { get; set; }

    [BsonElement("tipoHeroi")]
    [JsonProperty("tipoHeroi")] // A propriedade JSON e a Bson são mapeadas para "nome
    public TipoHeroiEnum TipoHeroi { get; set; }

    [BsonElement("classe")]
    [JsonProperty("classe")]  // A propriedade JSON e a Bson são mapeadas para "classe"
    public ClasseEnum Classe { get; set; }

    [BsonElement("atributo")]
    [JsonProperty("atributo")]  // A propriedade JSON e a Bson são mapeadas para "atributo"
    public AtributoEnum Atributo { get; set; }

    //public Heroi ToDomain() => new()
    //{
    //    Id = Id,
    //    Nome = Nome,
    //    Classe = Classe,
    //    Atributo = Atributo,
    //    //Traits = Traits
    //};

    //public static HeroiDocument FromDomain(Heroi h) => new()
    //{
    //    Id = h.Id,
    //    Nome = h.Nome,
    //    Classe = h.Classe,
    //    Atributo = h.Atributo,
    //    //Traits = h.Traits
    //};
}
