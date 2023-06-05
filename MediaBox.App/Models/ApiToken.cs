using Newtonsoft.Json;

namespace MediaBox.App.Models
{
    internal class ApiToken
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}