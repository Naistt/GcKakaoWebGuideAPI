using GcKakaoWebGuideAPI.Domain.Enums;

namespace GcKakaoWebGuideAPI.Domain.Entities;

public class Heroi
{
    public string Id { get; set; } = string.Empty;
    public required string Nome { get; set; }
    public TipoHeroiEnum TipoHeroi { get; set; }
    public ClasseEnum Classe { get; set; }
    public AtributoEnum Atributo { get; set; }
}
