namespace HelloRazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();       // Add razor pages service to DI container

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoint => endpoint.MapRazorPages());      // Add Map Razor Pages middleware to pipeline

            app.Run();
        }
    }
}