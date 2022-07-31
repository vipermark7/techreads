namespace techreads
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.Run(context => {
                var status = Configuration["status"];
                var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                context.Response.WriteAsync("Default Connection: " + connectionString);
                context.Response.WriteAsync("<br/>");
                return context.Response.WriteAsync("Status: " + status);
            });
        }
    }
}
