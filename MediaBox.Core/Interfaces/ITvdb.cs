namespace MediaBox.Core.Interfaces;

internal interface ITvdb
{
    [Get("/languages")]
    [Headers("Authorization: Bearer")]
    Task<ApiResponseLogin<List<ApiLanguage>>> GetLanguagesAsync();

    [Get("/search?query={query}&type={type}")]
    [Headers("Authorization: Bearer")]
    Task<Models.Api.ApiResponse<ApiMedia>> SearchAsync(string query, string? type = default, int year = default, string? company = default, string? country = default,
        string? director = default, string? language = default, string? primaryType = default, string? network = default, string? remote_id = default, int offset = default,
        int limit = default);
}