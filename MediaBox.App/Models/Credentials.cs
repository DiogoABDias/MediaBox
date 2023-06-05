using Newtonsoft.Json;

namespace MediaBox.App
{
    internal class Credentials
    {
        [JsonProperty(PropertyName = "apikey")]
        public string? ApiKey { get; set; }
        [JsonProperty(PropertyName = "pin")]
        public object? Pin { get; set; }
    }
}