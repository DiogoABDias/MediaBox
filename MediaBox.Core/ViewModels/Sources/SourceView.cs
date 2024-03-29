﻿namespace MediaBox.Core.ViewModels.Sources;

public class SourceView
{
    //Properties
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}