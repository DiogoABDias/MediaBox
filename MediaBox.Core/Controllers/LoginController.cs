namespace MediaBox.Core.Controllers;

public static class LoginController
{
    private static readonly ILogin _client;

    static LoginController() => _client = RestService.For<ILogin>("https://api4.thetvdb.com/v4");

    public static async Task LoginAsync()
    {
        try
        {
            Credentials credentials = new()
            {
                ApiKey = "580c9239-d2f8-4460-a22e-6831900a97a3",
                Pin = "IPQZOCMN"
            };

            Task<Response<ApiToken>> response = _client.LoginAsync(credentials);

            await response;

            if (response.Status != TaskStatus.RanToCompletion)
            {
                return;
            }

            if (response.Result.Status != "success")
            {
                return;
            }

            SourceController.Authorize(response.Result?.Data?.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}