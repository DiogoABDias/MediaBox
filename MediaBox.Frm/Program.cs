namespace MediaBox.Frm;
internal static class Program
{
    internal static IServiceProvider? ServiceProvider { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        IHost host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(ServiceProvider.GetRequiredService<FrmMain>());
    }

    static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<FrmMain>();

            services.AddSingleton<ICoreController, CoreController>();
            services.AddSingleton<IApplicationController, ApplicationController>();
            services.AddSingleton<ISourceController, SourceController>();
            services.AddSingleton<IMediaController, MediaController>();
            services.AddSingleton<IApiController, ApiController>();
        });
}