namespace MediaBox.Frm;
internal static class Program
{
    internal static SourcesView _sources = new();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        _sources = SourceController.GetSources();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmMain());
    }
}