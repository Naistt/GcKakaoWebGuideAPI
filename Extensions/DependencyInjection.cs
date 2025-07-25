using GcKakaoWebGuideAPI.Application.Services;
using GcKakaoWebGuideAPI.Infrastructure.Persistence.Repositories;
using GcKakaoWebGuideAPI.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GcKakaoWebGuideAPI.Infrastructure.Mapping;
using GcKakaoWebGuideAPI.Application.Interfaces;
using GcKakaoWebGuideAPI.Domain.Interfaces;

namespace GcKakaoWebGuideAPI.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IHeroiService, HeroiService>();
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoSettings>(config.GetSection("MongoSettings"));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IHeroiRepository, HeroiRepository>();
        return services;
    }
}