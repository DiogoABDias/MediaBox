namespace MediaBox.Core.Controllers;
public class SourceController : ISourceController
{
    private List<Source> _sources = new();

    public SourceController() => LoadSourcesAsync().Wait();

    public List<Source> GetSources(List<int>? sourceIds = default) => _sources.Where(x => sourceIds is null || sourceIds.Contains(x.Id)).ToList();

    private async Task LoadSourcesAsync()
    {
        try
        {
            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}sources.txt"))
            {
                return;
            }

            string content = await File.ReadAllTextAsync($"{AppDomain.CurrentDomain.BaseDirectory}sources.txt");
            _sources = JsonConvert.DeserializeObject<List<Source>>(content) ?? new();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    public async Task SaveSourcesAsync()
    {
        string content = JsonConvert.SerializeObject(_sources);
        await File.WriteAllTextAsync("sources.txt", content);
    }

    public void ApplySourceChanges(List<KeyValuePair<SourceView, SourceOperationType>> sourceChanges)
    {
        foreach (KeyValuePair<SourceView, SourceOperationType> sourceChange in sourceChanges)
        {
            try
            {
                SourceView sourceView = sourceChange.Key;
                int index;

                switch (sourceChange.Value)
                {
                    case SourceOperationType.Add:
                        int maxId = _sources.LastOrDefault()?.Id ?? 0;
                        Source source = new(maxId + 1, sourceView.Name, sourceView.Type.DehumanizeTo<MediaType>(), sourceView.Language, sourceView.Path);
                        _sources.Add(source);
                        break;
                    case SourceOperationType.Edit:
                        index = _sources.FindIndex(x => x.Id == sourceView.Id);
                        _sources[index] = new(sourceView.Id, sourceView.Name, sourceView.Type.DehumanizeTo<MediaType>(), sourceView.Language, sourceView.Path);
                        break;
                    case SourceOperationType.Delete:
                        index = _sources.FindIndex(x => x.Id == sourceView.Id);
                        _sources.RemoveAt(index);
                        break;
                }
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }
    }
}