﻿namespace MediaBox.Core.Models.Api;

internal class Credentials
{
    [JsonProperty(PropertyName = "apikey")]
    public string? ApiKey { get; set; }
    [JsonProperty(PropertyName = "pin")]
    public object? Pin { get; set; }
}