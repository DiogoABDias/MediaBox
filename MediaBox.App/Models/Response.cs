using Newtonsoft.Json;

namespace MediaBox.App.Models
{
    internal class Response<T>
    {
        [JsonProperty(PropertyName = "status")]
        public string? Status { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }
        [JsonProperty(PropertyName = "data")]
        public T? Data { get; set; }
    }
}