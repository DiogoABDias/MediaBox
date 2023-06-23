namespace MediaBox.Core.Models.Api;

internal class ApiToken
{
    [JsonProperty(PropertyName = "token")]
    public string? Token { get; set; }
}