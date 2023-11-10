namespace MediaBox.Core.Controllers;
public class ApiController : IApiController
{
    private readonly ILogin _login;
    private ITvdb? _client;

    internal ITvdb Client
    {
        get
        {
            if (_client is null)
            {
                throw new Exception("Client is null");
            }

            return _client;
        }
    }

    internal bool IsLoggedIn => _client is not null;

    public ApiController() => _login = RestService.For<ILogin>("https://api4.thetvdb.com/v4");

    ////////////////////////////////////////AUTHENTICATION////////////////////////////////////////

    public async Task LoginAsync()
    {
        try
        {
            ApiCredentials credentials = new()
            {
                ApiKey = "580c9239-d2f8-4460-a22e-6831900a97a3",
                Pin = "IPQZOCMN"
            };

            Task<ApiResponseLogin<ApiToken>> response = _login.LoginAsync(credentials);

            await response;

            if (response.Status != TaskStatus.RanToCompletion)
            {
                return;
            }

            if (response.Result.Status != "success")
            {
                return;
            }

            _client = RestService.For<ITvdb>("https://api4.thetvdb.com/v4",
                new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = (httpRequestMessage, continuationToken) => Task.FromResult(response.Result?.Data?.Token ?? "")
                });
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    ////////////////////////////////////////SEARCH////////////////////////////////////////

    public async Task<MediaInformation> SearchAsync(string query, int year, string type)
    {
        MediaInformation result = new();

        if (!IsLoggedIn)
        {
            return result;
        }

        try
        {
            Models.Api.ApiResponse<ApiMedia> response = await Client.SearchAsync(query, year: year, type: type);

            if (response.Status != "success")
            {
                return result;
            }

            if (response.Data is null || !response.Data.Any())
            {
                return result;
            }

            result = Mapping.Mapper.Map<MediaInformation>(response.Data.First());
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    ////////////////////////////////////////OTHER////////////////////////////////////////

    public async Task<LanguagesView> GetLanguagesAsync()
    {
        LanguagesView result = new();

        if (!IsLoggedIn)
        {
            return result;
        }

        Task<ApiResponseLogin<List<ApiLanguage>>> response = Client.GetLanguagesAsync();

        await response;

        if (response.Status != TaskStatus.RanToCompletion)
        {
            return result;
        }

        if (response.Result.Status != "success")
        {
            return result;
        }

        if (response.Result?.Data is null)
        {
            return result;
        }

        result.Languages = new();

        foreach (ApiLanguage language in response.Result.Data)
        {
            try
            {
                LanguageView languageView = new()
                {
                    Id = language.Id,
                    Name = language.Name,
                    NativeName = language.NativeName,
                    ShortCode = language.ShortCode
                };

                result.Languages.Add(languageView);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        return result;
    }
}