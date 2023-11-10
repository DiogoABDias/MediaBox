namespace MediaBox.Core.Interfaces;

internal interface ILogin
{
    [Post("/login")]
    Task<ApiResponseLogin<ApiToken>> LoginAsync([Body] ApiCredentials body);
}