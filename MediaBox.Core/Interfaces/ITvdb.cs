namespace MediaBox.Core.Interfaces;

internal interface ITvdb
{
    [Get("/languages")]
    [Headers("Authorization: Bearer")]
    Task<Response<List<Language>>> GetLanguagesAsync();
}