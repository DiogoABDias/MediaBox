namespace MediaBox.Core.Interfaces;
public interface ISourceController
{
    List<Source> GetSources(List<int>? sourceIds = default);

    Task SaveSourcesAsync();

    void ApplySourceChanges(List<KeyValuePair<SourceView, SourceOperationType>> sourceChanges);
}