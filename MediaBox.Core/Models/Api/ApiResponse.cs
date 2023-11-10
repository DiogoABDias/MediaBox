namespace MediaBox.Core.Models.Api;
internal class ApiResponse<T>
{
    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("data")]
    public List<T>? Data { get; set; }

    [JsonProperty("links")]
    public ApiLinks? Links { get; set; }
}