using MediaBox.App.Models;
using Refit;

namespace MediaBox.App
{
    internal interface ILogin
    {
        [Post("/login")]
        Task<Response<ApiToken>> LoginAsync([Body] Credentials body);
    }
}