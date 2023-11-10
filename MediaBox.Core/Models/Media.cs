namespace MediaBox.Core.Models;
abstract class Media
{
    //Properties
    internal string Name { get; private set; } = string.Empty;
    internal int Year { get; private set; }
    internal MediaType Type { get; private set; }
    internal int SourceId { get; private set; }
    internal MediaInformation Information { get; private set; } = new();

    //Constructor
    protected Media(string name, int year, MediaType type, int sourceId)
    {
        Name = name;
        Year = year;
        Type = type;
        SourceId = sourceId;
    }

    //Methods
    internal void AddInformation(MediaInformation information) => Information = information;
}