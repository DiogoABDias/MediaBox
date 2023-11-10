namespace MediaBox.Core.Interfaces;
public interface IMediaController
{
    MediaView GetMedia(MediaType mediaType);

    Task ScanSourcesAsync(List<Source> sources);
}