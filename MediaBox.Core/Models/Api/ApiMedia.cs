namespace MediaBox.Core.Models.Api;
internal class ApiMedia
{
    [JsonProperty("objectID")]
    public string? ObjectID { get; set; }

    [JsonProperty("aliases")]
    public List<string>? Aliases { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("image_url")]
    public string? ImageUrl { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("first_air_time")]
    public string? FirstAirTime { get; set; }

    [JsonProperty("overview")]
    public string? Overview { get; set; }

    [JsonProperty("primary_language")]
    public string? PrimaryLanguage { get; set; }

    [JsonProperty("primary_type")]
    public string? PrimaryType { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("tvdb_id")]
    public string? TvdbId { get; set; }

    [JsonProperty("year")]
    public string? Year { get; set; }

    [JsonProperty("slug")]
    public string? Slug { get; set; }

    [JsonProperty("overviews")]
    public ApiOverview? Overviews { get; set; }

    [JsonProperty("translations")]
    public ApiTranslation? Translations { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("remote_ids")]
    public List<ApiRemoteId>? RemoteIds { get; set; }

    [JsonProperty("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonProperty("extended_title")]
    public string? ExtendedTitle { get; set; }

    [JsonProperty("genres")]
    public List<string>? Genres { get; set; }

    [JsonProperty("studios")]
    public List<string>? Studios { get; set; }

    [JsonProperty("director")]
    public string? Director { get; set; }
}