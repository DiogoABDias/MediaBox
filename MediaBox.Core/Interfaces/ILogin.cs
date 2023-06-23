namespace MediaBox.Core.Interfaces;

internal interface ILogin
{
    [Post("/login")]
    Task<Response<ApiToken>> LoginAsync([Body] Credentials body);
}