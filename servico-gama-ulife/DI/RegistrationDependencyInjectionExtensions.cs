using Microsoft.Extensions.DependencyInjection;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Repository;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service;
using servico_gama_ulife.Service.Interface;

namespace servico_gama_ulife.DI
{
    public static class RegistrationDependencyInjectionExtensions
    {
        public static void AddRegistrationDependencies(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
            services.AddSingleton<IObjectConverter, ObjectConverter>();
        }
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IApiTesteRepository, ApiTesteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddScoped<IUserEvaluationRepository, UserEvaluationRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IApiTesteService, ApiTesteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();
            services.AddScoped<IUserEvaluationService, UserEvaluationService>();
        }
    }
}
