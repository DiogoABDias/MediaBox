namespace MediaBox.Core.Controllers;
public static class ApiController
{
    private static readonly ILogin _login;
    internal static ITvdb? _client;

    internal static ITvdb Client
    {
        get
        {
            if (_client is null)
            {
                throw new Exception();
            }

            return _client;
        }
    }

    static ApiController() => _login = RestService.For<ILogin>("https://api4.thetvdb.com/v4");

    public static async Task LoginAsync()
    {
        try
        {
            Credentials credentials = new()
            {
                ApiKey = "580c9239-d2f8-4460-a22e-6831900a97a3",
                Pin = "IPQZOCMN"
            };

            Task<Response<ApiToken>> response = _login.LoginAsync(credentials);

            await response;

            if (response.Status != TaskStatus.RanToCompletion)
            {
                return;
            }

            if (response.Result.Status != "success")
            {
                return;
            }

            Authorize(response.Result?.Data?.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    internal static void Authorize(string? token)
    {
        try
        {
            _client = RestService.For<ITvdb>("https://api4.thetvdb.com/v4",
                new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = (httpRequestMessage, continuationToken) => Task.FromResult(token ?? "")
                });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}