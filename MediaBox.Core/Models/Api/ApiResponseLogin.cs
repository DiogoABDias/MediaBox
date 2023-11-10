namespace MediaBox.Core.Models.Api;

internal class ApiResponseLogin<T>
{
    [JsonProperty(PropertyName = "status")]
    public string? Status { get; set; }
    [JsonProperty(PropertyName = "message")]
    public string? Message { get; set; }
    [JsonProperty(PropertyName = "data")]
    public T? Data { get; set; }
}