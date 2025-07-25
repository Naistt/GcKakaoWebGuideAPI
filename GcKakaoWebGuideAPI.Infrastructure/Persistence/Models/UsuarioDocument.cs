using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using GcKakaoWebGuideAPI.Domain.Entities;

namespace GcKakaoWebGuideAPI.Infrastructure.Persistence.Models;
public class UsuarioDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("nome")]
    public string Nome { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    //public static UsuarioDocument FromDomain(Usuario usuario) => new()
    //{
    //    Id = usuario.Id,
    //    Nome = usuario.Nome,
    //    Email = usuario.Email
    //};

    //public Usuario ToDomain() => new()
    //{
    //    Id = Id,
    //    Nome = Nome,
    //    Email = Email
    //};
}
