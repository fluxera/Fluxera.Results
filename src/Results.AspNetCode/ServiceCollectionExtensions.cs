namespace MadEyeMatt.Results.AspNetCode
{
    using JetBrains.Annotations;
    using MadEyeMatt.Results.AspNetCode.Transformers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Extension methods for the <see cref="IServiceCollection"/> type.
    /// </summary>
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
		/// <summary>
		///     Adds the <see cref="ProblemDetailsActionResultTransformer"/> to the service collection.
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddProblemDetailsActionResultTransformer(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IActionResultTransformer>(serviceProvider =>
            {
                IHttpContextAccessor httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                return new ProblemDetailsActionResultTransformer(httpContextAccessor.HttpContext);
            });

            return services;
        }

#if NET7_0_OR_GREATER
		/// <summary>
		///     Adds the <see cref="ProblemDetailsHttpResultTransformer"/> to the service collection.
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddProblemDetailsHttpResultTransformer(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpResultTransformer>(serviceProvider =>
            {
                IHttpContextAccessor httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                return new ProblemDetailsHttpResultTransformer(httpContextAccessor.HttpContext);
            });

            return services;
        }
#endif
	}
}