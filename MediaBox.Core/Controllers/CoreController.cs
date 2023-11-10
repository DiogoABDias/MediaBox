namespace MediaBox.Core.Controllers;
public class CoreController : ICoreController
{
    public static async Task<string> GetLatestVersionNameAsync(string currentVersion)
    {
        string result = string.Empty;

        try
        {
            GitHubClient client = new(new ProductHeaderValue("MediaBox"));
            Release release = await client.Repository.Release.GetLatest("DiogoABDias", "MediaBox");

            Version latestGitHubVersion = new(release.TagName[1..]);
            Version localVersion = new(currentVersion);
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);

            result = versionComparison < 0 ? release.Name : string.Empty;
        }
        catch (NotFoundException)
        {
        }
        catch (Exception ex)
        {
            Log.Fatal(ex);
        }

        return result;
    }

    public static async Task<string> GetLatestVersionUrlAsync()
    {
        string result = string.Empty;

        try
        {
            GitHubClient client = new(new ProductHeaderValue("MediaBox"));
            Release release = await client.Repository.Release.GetLatest("DiogoABDias", "MediaBox");

            result = release.Assets[0].BrowserDownloadUrl;
        }
        catch (NotFoundException)
        {
        }
        catch (Exception ex)
        {
            Log.Fatal(ex);
        }

        return result;
    }

    public void PlayVideo(string file, string subtitle)
    {
        try
        {
            //--qt-continue={0 (Never), 1 (Ask), 2 (Always)}
            //.\vlc.exe "path\video.mp4" --no-sub-autodetect-file --sub-file="path\subtitles.srt" --qt-continue=2
            ProcessStartInfo startInfo = new("C:\\Program Files\\VideoLAN\\VLC\\vlc.exe")
            {
                Arguments = $"\"{file}\" --no-sub-autodetect-file --sub-file=\"{subtitle}\" --qt-continue=2"
            };

            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex);
        }
    }
}