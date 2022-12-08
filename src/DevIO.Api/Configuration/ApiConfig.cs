namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {
        public static IApplicationBuilder UseWebApiConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
