namespace MediaBox.Core.Controllers;
public static class CoreController
{
    public static async Task<string> GetLatestVersionNameAsync(string currentVersion)
    {
        try
        {
            GitHubClient client = new(new ProductHeaderValue("MediaBox"));
            Release release = await client.Repository.Release.GetLatest("DiogoABDias", "MediaBox");

            Version latestGitHubVersion = new(release.TagName[1..]);
            Version localVersion = new(currentVersion);
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);

            return versionComparison < 0 ? release.Name : string.Empty;
        }
        catch (NotFoundException)
        {
        }
        catch (Exception ex)
        {
            Log.Fatal(ex);
        }

        return string.Empty;
    }

    public static async Task<string> GetLatestVersionUrlAsync()
    {
        GitHubClient client = new(new ProductHeaderValue("MediaBox"));
        Release release = await client.Repository.Release.GetLatest("DiogoABDias", "MediaBox");

        return release.Assets[0].BrowserDownloadUrl;
    }
}