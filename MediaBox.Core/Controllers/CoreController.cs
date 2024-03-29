﻿namespace MediaBox.Core.Controllers;
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
        catch (Exception exception)
        {
            Log.Fatal(exception);
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
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    public void PlayVideo(string path)
    {
        try
        {
            //--qt-continue={0 (Never), 1 (Ask), 2 (Always)}
            //.\vlc.exe "path\video.mp4" --no-sub-autodetect-file --sub-file="path\subtitles.srt" --qt-continue=2
            ProcessStartInfo startInfo = new("C:\\Program Files\\VideoLAN\\VLC\\vlc.exe")
            {
                Arguments = "\"E:\\Movies\\The Matrix Reloaded\\The.Matrix.Reloaded.2003.1080p.BrRip.x264.YIFY.mp4\" --no-sub-autodetect-file --sub-file=\"E:\\Movies\\The Matrix Reloaded\\The.Matrix.Reloaded.2003.1080p.BrRip.x264.YIFY.srt\" --qt-continue=2"
            };

            Process.Start(startInfo);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }
}